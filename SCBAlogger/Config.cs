using SCBAlogger.Model;
using SCBAlogger.Data;
using System.Data;
using System.Diagnostics;

// Maintain the configuration data for the SCBAlogger

namespace SCBAlogger
{
    public partial class Config : Form
    {
        private readonly SCBAContext _context;
        public bool is_updated = false;
        public string ConfiguredEventName { get; private set; } = "";
        readonly private short category = 1;
        private string eventName = "";
        string source = "SCBAlogger";
        string logName = "Application";
        public Config(SCBAContext context)
        {
            InitializeComponent();
            _context = context;
            // Is the the problem child with the DI??
            eventLog.Source = source;
            eventLog.Log = logName;

            // Let it be known that we'll be drawing each row of the operator box

            operatorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            operatorComboBox.DrawItem += OperatorComboBox_DrawItem;

            jurisdictionComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            jurisdictionComboBox.DrawItem += JurisdictionCombobox_DrawItem;


        }

       


        private void Config_Load(object sender, EventArgs e)
        {

            LoadOperators();

            LoadJurisdictions();

            this.toolStripStatusLabel1.Text = "";
        }


        private void LoadOperators()
        {
            //operatorComboBox.DataSource = _context.Operators.ToList();
            // Filters the operator list to only show the active operators.
            operatorComboBox.DataSource = _context.Operators.ToList();
            operatorComboBox.DisplayMember = "OperatorName";
            operatorComboBox.ValueMember = "Id";
        }
        private void LoadJurisdictions()
        {
            jurisdictionComboBox.DataSource = _context.Jurisdictions.ToList();
            jurisdictionComboBox.DisplayMember = "Name";
            jurisdictionComboBox.ValueMember = "Id";
        }

        #region Operator

        private void OperatorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Get the Operator object for this row
            var op = (Operator)operatorComboBox.Items[e.Index];

            // Choose color based on IsActive
            Color textColor = op.IsActive ? Color.Black : Color.Gray;

            // Draw background
            e.DrawBackground();

            // Draw text
            using (Brush brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(
                    op.OperatorName,
                    e.Font,
                    brush,
                    e.Bounds
                );
            }

            e.DrawFocusRectangle();
        }


        private void OperatorButtonAdd_Click(object sender, EventArgs e)
        {
            string selectedItem = operatorComboBox.Text.Trim();
            // validate the input


            if (string.IsNullOrEmpty(selectedItem))
            {

                MessageBox.Show("Please enter or select an item.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var items = operatorComboBox.Items.Cast<Operator>()
                .Select(op => op.OperatorName)
                .ToList();

            bool exists = items.Contains(selectedItem, StringComparer.OrdinalIgnoreCase);

            if (exists)
            {
                MessageBox.Show("Item already exists in the list.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _context.Operators.Add(new Operator { OperatorName = selectedItem });
                _context.SaveChanges();
                eventLog.WriteEntry($"Saved Event Name to database: {selectedItem}", EventLogEntryType.Information, 9001);
                this.toolStripStatusLabel1.Text = "Operator Saved.";
                this.toolStripStatusLabel1.BackColor = Color.Green;
                this.toolStripStatusLabel1.ForeColor = Color.White;
                LoadOperators();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save Operator to database: {ex.Message}");
                this.toolStripStatusLabel1.Text = "Failed to save Operatpr.";
                this.toolStripStatusLabel1.BackColor = Color.Tomato;
                eventLog.WriteEntry($"Failed to save Operatpr to database: {ex.Message}", EventLogEntryType.Error, 9001);
            }

        }

        private void OperatorButtonInactivate(object sender, EventArgs e)
        {
            if (operatorComboBox.SelectedValue == null) return;

            int id = (int)operatorComboBox.SelectedValue;

            var op = _context.Operators.First(o => o.Id == id);

            if (op != null)
            {
                // Toggle the active state. Do the same for Jurisdictions
                op.IsActive = !op.IsActive;
                _context.SaveChangesAsync();
                eventLog.WriteEntry($"Mark Operator Inactive in database: {op.OperatorName}", EventLogEntryType.Information, 9001);
                this.toolStripStatusLabel1.Text = "Operator  Updated.";
                this.toolStripStatusLabel1.BackColor = Color.Green;
                this.toolStripStatusLabel1.ForeColor = Color.White;
            }
            else
            {
                MessageBox.Show("Failed to find the selected Operator in the database.");
                this.toolStripStatusLabel1.Text = "Failed to delete Operator.";
                this.toolStripStatusLabel1.BackColor = Color.Tomato;
                eventLog.WriteEntry($"Failed to find the selected Operator in the database for deletion.", EventLogEntryType.Error, 9002);
            }

        }
        #endregion

        #region Event
        private void btnEventSave_Click(object sender, EventArgs e)
        {
            string format = "yyyy-MM-dd HH:mm:ss";

            string name = txtBoxEvent.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter an Event name.", "Validation");
                return;
            }
            // Update the application property.
            Properties.Settings.Default.EventName = this.txtBoxEvent.Text;
            Properties.Settings.Default.Save();

            // Store this into the database
            try
            {
                Event anEvent = new Event();
                anEvent.Name = name;
                anEvent.EventDate = DateTime.Now.ToShortDateString() == DateTime.Now.ToString(format).Substring(0, 10) ? DateTime.Now : DateTime.ParseExact(DateTime.Now.ToString(format), format, null);

                _context.Events.Add(anEvent);

                _context.SaveChanges();
                eventLog.WriteEntry($"Saved Event Name to database: {name}", EventLogEntryType.Information, 9003);
                this.toolStripStatusLabel1.Text = "Event Name saved.";
                this.toolStripStatusLabel1.BackColor = Color.Green;
                this.toolStripStatusLabel1.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save Event Name to database: {ex.Message}");
                this.toolStripStatusLabel1.Text = "Failed to save Event Name.";
                this.toolStripStatusLabel1.BackColor = Color.Tomato;
                eventLog.WriteEntry($"Failed to save Event Name to database: {ex.Message}", EventLogEntryType.Error, 9004);
            }


            is_updated = true;
        }

        // Events have no Delete  
        #endregion 

        #region Jurisdiction

        private void JurisdictionCombobox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Get the Jurisdiction object for this row
            var op = (Jurisdiction)jurisdictionComboBox.Items[e.Index];

            // Choose color based on IsActive
            Color textColor = op.IsActive ? Color.Black : Color.Gray;

            // Draw background
            e.DrawBackground();

            // Draw text
            using (Brush brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(
                    op.Name,
                    e.Font,
                    brush,
                    e.Bounds
                );
            }

            e.DrawFocusRectangle();
        }

        private void JurisdictionAddButton_Click(object sender, EventArgs e)
        {
            string selectedItem = jurisdictionComboBox.Text.Trim();
            if (string.IsNullOrEmpty(selectedItem))
            {
                MessageBox.Show("Please enter or select an item.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var items = jurisdictionComboBox.Items.Cast<Jurisdiction>()
                .Where(o => o.IsActive)
                .Select(o => o.Name)
                .ToList();

            bool exists = items.Contains(selectedItem, StringComparer.OrdinalIgnoreCase);

            if (exists)
            {
                MessageBox.Show("Item already exists in the list.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _context.Jurisdictions.Add(new Jurisdiction { Name = selectedItem, IsActive= true });
                _context.SaveChanges();
                eventLog.WriteEntry($"Saved Jurisdiction to database: {selectedItem}", EventLogEntryType.Information, 9005);
                this.toolStripStatusLabel1.Text = "Jurisdiction saved.";
                this.toolStripStatusLabel1.BackColor = Color.Green;
                this.toolStripStatusLabel1.ForeColor = Color.White;
                LoadJurisdictions();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save Jurisdiction to database: {ex.Message}");
                this.toolStripStatusLabel1.Text = "Failed to save Jurisdiction.";
                this.toolStripStatusLabel1.BackColor = Color.Tomato;
                eventLog.WriteEntry($"Failed to save Jurisdiction to database: {ex.Message}", EventLogEntryType.Error, 9006);
            }

        }

        private void JurisdictionDeleteButton_Click(object sender, EventArgs e)
        {
            if (jurisdictionComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a Jurisdiction to deactivate. I will no longer appear as a selection.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = (int)jurisdictionComboBox.SelectedValue;
            var jurisdiction = _context.Jurisdictions.Find(id);
            if (jurisdiction != null)
            {
                jurisdiction.IsActive = !jurisdiction.IsActive; 
                _context.SaveChanges();
                eventLog.WriteEntry($"Deactivated Jurisdiction from database: {jurisdiction.Name}", EventLogEntryType.Information, 9007);
                this.toolStripStatusLabel1.Text = "Jurisdiction deactivated.";
                this.toolStripStatusLabel1.BackColor = Color.Green;
                this.toolStripStatusLabel1.ForeColor = Color.White;
                LoadJurisdictions();

            }
            else
            {
                MessageBox.Show("Failed to find the selected Jurisdiction in the database.");
                this.toolStripStatusLabel1.Text = "Failed to delete Jurisdiction.";
                this.toolStripStatusLabel1.BackColor = Color.Tomato;
                eventLog.WriteEntry($"Failed to find the selected Jurisdiction in the database for deactivation.", EventLogEntryType.Error, 9008);
            }
        }
        #endregion

        #region things that are not needed

        private void TabControlConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clear the status strip
            this.toolStripStatusLabel1.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabJuristictions_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
