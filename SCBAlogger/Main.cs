using AdysTech.CredentialManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;

//using OfficeOpenXml;
using SCBAlogger.Data;
using SCBAlogger.Model;
using SCBAlogger.Model.DTOS;
using SCBAlogger.Properties;
using SCBAlogger.Service;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Drawing.Text;
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
       
        private Boolean isValidHydrostate = false;
        private Boolean isValidSerialNumber = false;
        private readonly IServiceProvider _services;
        private bool _isShuttingDown = false;
       
        private bool isCreated;

        #region Main Constructors
        // Parameterless constructor kept for designer support

        public Main()
        {
            InitializeComponent();
            //    private readonly SCBAContext context = new SCBAContext();
            _isShuttingDown = false;
             this.FormClosing += MainForm_FormClosing;
             this.Shown += Main_Shown;
            
        }

        public Main(SCBAContext context)
        {
            InitializeComponent();
            _isShuttingDown = false;
            this.FormClosing += MainForm_FormClosing;
            this.Shown += Main_Shown;
            _context = context;
        }

        // Check to see if the event source is available if not create it and log the start
        private async void Main_Shown(object sender, EventArgs e)
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
                //iscreated = await _eventService.CanConnectAsync();
                iscreated = _context.Database.CanConnect();
                if (!iscreated)
                    throw new Exception();

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
        #endregion

        #region Control Updaters

        private void UpdateJurisdictionList()
        {
            var filteredJurisdictions = _context.Jurisdictions
               .Where(j => j.IsActive).OrderBy(j => j.Name).ToList();

            JurisdictionCombo.DataSource = filteredJurisdictions;
        }

        private void UpdateScannedTanksGrid()
        {
    
            //TODO: Remove this test fixture
            string x = "Training Event";
            var filteredScans = _context.ScannedTanks.Where(s => s.Name == x).ToList();
            this.dataGridView1.DataSource = filteredScans;
        }

        private void UpdateOperatorList()
        {
            var filteredOperators = _context.Operators.Where(s => s.IsActive).ToList();
            comboBoxOperators.DataSource = filteredOperators;
        }

        #endregion

        #region .Net Event Handlers


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
            using (Config dialog = new Config(_context))
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
                        this.labelScans.Text = "Event: " + eventName;
                        this.labelScans.ForeColor = SystemColors.ControlText;
                        this.labelScans.BackColor = SystemColors.Control;
                    }
                }


                UpdateScannedTanksGrid();

                UpdateOperatorList();

                UpdateJurisdictionList();


                eventLog.WriteEntry("Application Configured", EventLogEntryType.Information, 10003, category);
            }
        }

        #region unused event handlers
        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cursor.Current = Cursors.WaitCursor;
            //CreateNewWorkBook();
            //Cursor.Current = Cursors.Default;


        }


        private void Email_Click(object sender, EventArgs e)
        {

        }


        private void Create_Click(object sender, EventArgs e)
        {
            // CreateNewWorkBook();


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Shutdown

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isShuttingDown)
                return;

            e.Cancel = true; // prevent immediate close
            _isShuttingDown = true;

            // TODO: Remove the last bit if DI
            var dlg = new ProgressDialog();
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
            //await CreateWorkbookAsync();

            dlg.UpdateStatus("Flushing logs...", Percent(++step, total));
            await Task.Delay(1000);
            await CreateWorkbooks();

            dlg.UpdateStatus("Closing database...", Percent(++step, total));
            await Task.Delay(1000);
            await CloseDatabaseAsync();
        }

        private int Percent(int step, int total)
        {
            return (int)((step / (double)total) * 100);
        }

        private async Task CreateWorkbookAsync()
        // There should only EVER be one event without a workbook, but
        // it's a check will be made. 
        {
           var events = 
           await _context.SaveChangesAsync();
        }


        private async Task CreateWorkbooks()
        {

            List<UnprocessedEventDto> events = await _context.GetUnprocessedEventsAsync();
            int missingWorkBooks = events.Count;
            /// Move this to the event Service???
            foreach (UnprocessedEventDto ev in events)
            {
                Debug.WriteLine($"event {ev.EventId}, {ev.EventName}");
                // Create a new workbook for the event using the name and the date. eg: Cropp Rd 2/7/2026.
                // Determine the number of jurisdictions in the event.
             
                var scans = await _context.GetEventScansAsync(ev.EventId);
               
                Debug.WriteLine(scans.Count);
                //  Generate the workbook or ev.EventName and Event.Date.
                WorkbookService workbookService = new WorkbookService();    
                workbookService.Create(ev,scans);
            }




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




        private bool IsRunningAsAdmin()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
    }
}


