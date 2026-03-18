using AdysTech.CredentialManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

namespace SCBAlogger
{
    public partial class Main : Form
    {
        // this is the category for the error logging. 
        readonly private short category = 1;
        private string eventName = "";
        readonly private static string serialNumberRegEx = "[A-Z]{3}[0-9]{6}";
        readonly private static string hydrostatDateRegEx = "[0-9]{4}";
        private string source = "SCBALogger";
        private string logName = "Application";
        private readonly SCBAContext _context;
        private BindingSource _bindingSource = new BindingSource();
        private Boolean isValidHydrostate   = false;
        private Boolean isValidSerialNumber = false;



        // Parameterless constructor kept for designer support
        public Main()
        {
            InitializeComponent();
            this.Shown += Main_Shown;
        }

        // Constructor used by DI at runtime
        public Main(SCBAContext context)
        {
            _context = context;
            InitializeComponent();


      
       
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
                AddUserPropertiesToListBox(pressureListbox, SCBAlogger.Properties.Settings.Default.TankPressures);
                AddUserPropertiesToListBox(jurisdictionListbox, SCBAlogger.Properties.Settings.Default.Jurisdictions);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Logging failed: {ex.Message}");

            }

            


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
                MessageBox.Show("Cannot connect to the database. Check your connection string (appsettings.json or SCBALOGGER_CONNECTION) and ensure SQL Server is available.", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.applicationStatus.Text = "DB Unavailable";
                this.applicationStatus.BackColor = Color.IndianRed;
                dataGridView1.DataSource = null;
                return;
            }

            _bindingSource.DataSource = _context.ScannedTanks.ToList();
            dataGridView1.DataSource = _bindingSource;
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
            using (Config dialog = new Config())
            {
                if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.applicationStatus.Text = "Ready";
                    this.applicationStatus.BackColor = Color.Green;
                    this.scannerData.Enabled = true;

                    if (dialog.is_updated)
                    {
                        eventLog.WriteEntry("Application Config updated", EventLogEntryType.Information, 10002);
                        this.toolStripStatusLabel2.Text = "Configuration Updated";
                        eventName = SCBAlogger.Properties.Settings.Default.EventName;

                        this.labelEvent.Text = "Event: " + eventName;

                    }


                }

            }

            eventLog.WriteEntry("Application Configured", EventLogEntryType.Information, 10003, category);


        }



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

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void AddUserPropertiesToListBox(object sender, string foo)
        {
            ListBox lb = (ListBox)sender;
            String[] array = foo.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            lb.Items.Clear();
            lb.Items.AddRange(array);


        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cursor.Current = Cursors.WaitCursor;
            //CreateNewWorkBook();
            //Cursor.Current = Cursors.Default;


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
    }
}

