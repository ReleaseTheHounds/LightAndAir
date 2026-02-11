using SCBAlogger.Model;
using System.Diagnostics;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace SCBAlogger
{
    public partial class Main : Form
    {
        // this is the category for the error logging. 
        readonly private short category = 1;
        private string eventName = "";
        readonly private static string serialNumberRegEx = "[A-Z]{3}[0-9]{6}";
        readonly private static string hydrostatDateRegEx = "[0-9]{4}";

        private readonly ScbaContext _context = new ScbaContext();
        private BindingSource _bindingSource = new BindingSource();


        public Main()
        {
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
                string source = "SCBALogger";
                string logName = "Application";

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

            bool iscreated = _context.Database.CanConnect();

            _bindingSource.DataSource = _context.ScannedTanks.ToList();

            dataGridView1.DataSource = _bindingSource;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (About dialog = new About())
            {
                // Show the dialog with the current form as owner
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    // No data returned from the About Dialog
                    ;
                }
                else
                {

                }
            }
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
                if (dialog.ShowDialog(this) == DialogResult.OK)
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
            this.hydrostatText.Text = text;
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
                this.serialNumberText.Text = scannerString;
            }
            else if (hydostatDateTest.IsMatch(scannerString))
            {
                this.hydrostatText.Text = scannerString;
            }
        }

        private void CreateABarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CreateBarcode dialog = new CreateBarcode())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
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
    }
}

