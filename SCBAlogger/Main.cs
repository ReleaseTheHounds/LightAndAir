using AdysTech.CredentialManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;

//using OfficeOpenXml;
using SCBAlogger.Data;
using SCBAlogger.Model;
using SCBAlogger.Properties;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Net;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using ZXing.Client.Result;

namespace SCBAlogger
{
    public partial class Main : Form
    {
        // this is the category for the error logging. 
        readonly private short category = 1;
        private string eventName = "";
        readonly private static string serialNumberRegEx = "[A-Z]{3}[0-9]{6}";
        readonly private static string hydrostatDateRegEx = "[0-9]{4}";
        private string source = "SCBAlogger";
        private string logName = "Application";
        private readonly SCBAContext _context;
        private readonly Config _config;
        // Binding sources for the controls
        private BindingSource _bindingSourceScans = new BindingSource();
        private BindingSource _bindingSourceOperators = new BindingSource();
        private BindingSource _bindingSourceJurisdictions = new BindingSource();
        private Boolean isValidHydrostate = false;
        private Boolean isValidSerialNumber = false;
        private readonly IServiceProvider _services;
        private bool _isShuttingDown = false;   
        // Parameterless constructor kept for designer support
        public Main()
        {
            InitializeComponent();
            this.Shown += Main_Shown;
        }

        // Constructor used by DI at runtime
        public Main(SCBAContext context, IServiceProvider services)
        {
            InitializeComponent();
            _context = context;
            _services = services;
            this.FormClosing += MainForm_FormClosing;

            this.Shown += Main_Shown;
        }

        private bool IsRunningAsAdmin()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }


        // Check to see if the event source is available if not create it and log the start
        private void Main_Shown(object sender, EventArgs e)
        {
            try
            {
                if (!EventLog.SourceExists(source))
                {
                    // TODO: shell out to the CreateLog source with UAC to create the log source if not running as adming.
                }
                eventLog.Source = source;
                eventLog.Log = logName;
                eventLog.WriteEntry("Started", EventLogEntryType.Information, 10000, category);
                System.Diagnostics.Debug.WriteLine(SCBAlogger.Properties.Settings.Default.TankPressures);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Logging failed: {ex.Message}");
            }

            // Tank Pressure
            AddUserPropertiesToListBox(pressureListbox, SCBAlogger.Properties.Settings.Default.TankPressures);

            bool iscreated = false;
            try
            {
                iscreated = _context.Database.CanConnect();
            }
            catch (Exception ex)
            {
                // Log and treat as not created
                MessageBox.Show($"Database connectivity check failed: {ex.Message}", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iscreated = false;
            }

            if (!iscreated)
            {
                MessageBox.Show("Cannot connect to the database. Check your connection string (appsettings.json or SCBAlogger_CONNECTION) and ensure SQL Server is available.", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.applicationStatus.Text = "DB Unavailable";
                this.applicationStatus.BackColor = Color.IndianRed;
                dataGridView1.DataSource = null;
                return;
            }

            UpdateOperatorList();
            UpdateJurisdictionList();
             
        }

        #region Control Updaters

        private void UpdateJurisdictionList()
        {
            var filteredJurisdictions = _context.Jurisdictions
               .Where(j => j.IsActive).ToList();

            JurisdictionCombo.DataSource = filteredJurisdictions;
        }
       
        private void UpdateScannedTanksGrid()
        {
            Console.Write(this.eventName);
            string x = "Training Event";
            var filteredScans = _context.ScannedTanks.Where(s => s.Name == x).ToList();
            this.dataGridView1.DataSource = filteredScans;
        }

        private void UpdateOperatorList()
        {
            var filteredOperators = _context.Operators
                    .Where(o => o.IsActive)
                       .OrderBy(o => o.OperatorName)
                       .ToList();

            comboBoxOperators.DataSource = filteredOperators;
        }

        #endregion

        #region Evemt Handlers
        private void CreateABarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CreateBarcode dialog = new CreateBarcode())
            {
                if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // Eventually may want to do something with the returned image.
                }
            }
        }
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eventLog.WriteEntry("Normal Exit", EventLogEntryType.Information, 10001, category);

            Application.Exit();

        }

        private void ConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = _services.GetRequiredService<Config>();


            if (child.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.applicationStatus.Text = "Ready";
                this.applicationStatus.BackColor = Color.Green;
                this.scannerData.Enabled = true;

                if (child.is_updated)
                {
                    eventLog.WriteEntry("Application Config updated", EventLogEntryType.Information, 10002);
                    this.toolStripStatusLabel2.Text = "Configuration Updated";

                    eventName = SCBAlogger.Properties.Settings.Default.EventName;
                    this.labelScans.Text = "Event: " + eventName;
                    this.labelScans.ForeColor = SystemColors.ControlText;
                    this.labelScans.BackColor = SystemColors.Control;
                }

                UpdateScannedTanksGrid();
                UpdateOperatorList();
                UpdateJurisdictionList();
            }



            eventLog.WriteEntry("Application Configured", EventLogEntryType.Information, 10003, category);
        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cursor.Current = Cursors.WaitCursor;
            //CreateNewWorkBook();
            //Cursor.Current = Cursors.Default;


        }

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    base.OnFormClosing(e);

        //    var x = 2 + 4;
        //    // This fires when:
        //    // - User clicks X
        //    // - Application.Exit()
        //    // - Environment.Exit()
        //    // - Windows shutdown/logoff (Reason = WindowsShutDown)
        //}

        #region Shutdown

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isShuttingDown)
                return;

            e.Cancel = true; // prevent immediate close
            _isShuttingDown = true;

            var dlg = _services.GetRequiredService<ProgressDialog>();
            dlg.Show();

           await RunShutdownTasksAsync(dlg);

            dlg.Close();
            this.Close();

        }

        private async Task RunShutdownTasksAsync(ProgressDialog dlg)
        {
            int step = 0;
            int total = 3; // number of tasks

            dlg.UpdateStatus("Saving operator changes...", Percent(++step, total));
            await Task.Delay(1000);
            await SaveOperatorChangesAsync();
            
            dlg.UpdateStatus("Flushing logs...", Percent(++step, total));
            await Task.Delay(1000);
            await FlushLogsAsync();

            dlg.UpdateStatus("Closing database...", Percent(++step, total));
            await Task.Delay(1000);
            await CloseDatabaseAsync();
        }

        private int Percent(int step, int total)
        {
            return (int)((step / (double)total) * 100);
        }

        private async Task SaveOperatorChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        private async Task FlushLogsAsync()
        {
            await _context.SaveChangesAsync();
        }

        private async Task CloseDatabaseAsync()
        {
            await _context.Database.CloseConnectionAsync();
        }


        #endregion

        #endregion

        #region input handlers

        private void HydrostatUpdate(string text)
        {
            hydrostatText.Text = text;
            return;
        }
        private void SerialNumberUpdate(string text)
        {
            serialNumberText.Text = text;
            return;
        }

        private void ScannerData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyValue == 13)
            {
                ProcessScannerData();
            }

        }

        private void ProcessScannerData()
        {
            string scannerString = this.scannerData.Text.Trim();
            Regex serialNumberTest = new Regex(serialNumberRegEx, RegexOptions.None);
            Regex hydostatDateTest = new Regex(hydrostatDateRegEx, RegexOptions.None);


            if (serialNumberTest.IsMatch(scannerString))
            {
                SerialNumberUpdate(scannerString);
            }
            else if (hydostatDateTest.IsMatch(scannerString))
            {
                HydrostatUpdate(scannerString);

            }
            else
            {

            }

        }

        #endregion

    

        private void Main_Load(object sender, EventArgs e)
        {

        }

        //TODO: Pull this data from the database if it is available
        private void AddUserPropertiesToListBox(object sender, string foo)
        {
            ListBox lb = (ListBox)sender;
            String[] array = foo.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            lb.Items.Clear();
            lb.Items.AddRange(array);

        }

    

        //private void CreateNewWorkBook()
        //{
        //    ExcelPackage.License.SetNonCommercialPersonal("Stafford County Fire and Rescue");
        //    using (var package = new ExcelPackage())
        //    {
        //        var events = _context.UnprocessedEvents
        //       .FromSql($"Execute dbo.GetUnprocessedEvents")
        //       .ToList();
        //        string? sheetName = String.Empty;
        //        if (events.Count > 0)
        //        {
        //            // TODO: the resuls are now orders on EventDate to premit them to be batched on Month and Year. Add the checks for changes in Month  and year to close out a workbook and start another
        //            DateTime tmpDate = events[0].EventDate;
        //            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(tmpDate.Month);
        //            string workbookName = $"C:\\temp\\Scans{monthName}{tmpDate.Year}.xlsx";
        //            // this creates a permonth/year workbook for the events.
        //            // If there are multiple events in the same month they will be added to the same workbook but different sheets.
        //            WindowsLog.WriteLogEntry(EventLogEntryType.Information, $"Retrieved {events.Count} unprocessed events from the database", 7001);
        //            foreach (UnprocessedEvents t in events)
        //            {
        //                sheetName = $"{t.Name}";
        //                DateTime eventDate = t.EventDate;
        //                if ( sheetName == "")
        //                {
        //                    throw new Exception("Event Name is null or empty, cannot create sheet name");
        //                }
        //                var sheet = package.Workbook.Worksheets.Add(sheetName);
        //                var stuff = _context.EventScans
        //                     .FromSql($"Execute dbo.GetEventScans {t.ID}")
        //                     .ToList();
        //                WindowsLog.WriteLogEntry(EventLogEntryType.Information, $"Retrieved {stuff.Count} scans for event {t.ID}", 7002);

        //                sheet.Cells["A1"].LoadFromCollection(stuff, true);
        //                package.SaveAs(workbookName);

        //                Event anEvent = _context.Events.Find(t.ID);
        //                if (anEvent !=null)
        //                {
        //                    anEvent.ExcelFileName = workbookName;
        //                }  
        //            }
        //            _context.SaveChanges();
        //        }
        //    }
        //}


        private void Email_Click(object sender, EventArgs e)
        {
            //string secretProperty = Settings.Default.EmailSecretName;
            //string txtPassword;
            //string txtAccountName;
            //NetworkCredential emailCredential;

            //var cred = CredentialManager.GetCredentials(secretProperty);


            //if (cred != null)
            //{
            //    txtPassword = cred.Password;
            //    txtAccountName = cred.UserName;

            //    emailCredential = new NetworkCredential(txtAccountName, txtPassword);
            //    WindowsLog.WriteLogEntry(EventLogEntryType.Information, $"Retrieved the secret for {secretProperty}", 20002);
            //}
            //else
            //{
            //    MessageBox.Show("No secret found.");
            //    WindowsLog.WriteLogEntry(EventLogEntryType.Error, $"No secret found for {secretProperty}", 2003);
            //    return;
            //}

            //MimeMessage msg = new MimeMessage();
            //msg.From.Add(new MailboxAddress(txtAccountName, $"{txtAccountName} @gmail.com"));

            //var addresses = Settings.Default.DestinationEmailAddresses.Split(',', StringSplitOptions.RemoveEmptyEntries);
            //foreach (string name in addresses)
            //{
            //    String txtName = name.Split("@")[0];
            //    msg.To.Add(new MailboxAddress(txtName, name));
            //}

            //msg.Subject = "AirSpreadsheets";
            //var body = new TextPart("plain")
            //{
            //    Text = "Please find attached the latest batch of SCBA fill workbooks/spreadsheets."
            //};

            //var attachmentPath = @"C:\temp\ScansFebruary2026.xlsx";
            //var attachment = new MimePart("application", "xlsx")
            //{
            //    Content = new MimeContent(File.OpenRead(attachmentPath)),
            //    ContentDescription = ContentDisposition.Attachment,
            //    ContentTransferEncoding = ContentEncoding.Base64,
            //    FileName = Path.GetFileName(attachmentPath)
            //};

            //var multipart = new Multipart("mixed");
            //multipart.Add(body);
            //multipart.Add(attachment);
            //msg.Body = multipart;

            //using (var client = new SmtpClient())
            //{
            //    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

            //    // Use App Password (not your regular Gmail password)
            //    client.Authenticate(txtAccountName, txtPassword);

            //    client.Send(msg);
            //    client.Disconnect(true);
            //}
        }


        private void Create_Click(object sender, EventArgs e)
        {
            // CreateNewWorkBook();


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

