namespace SCBAlogger
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TabControlConfig = new TabControl();
            tabEvent = new TabPage();
            btnEventSave = new Button();
            label1 = new Label();
            txtBoxEvent = new TextBox();
            tabOperators = new TabPage();
            buttonDelete = new Button();
            buttonAdd = new Button();
            operatorComboBox = new ComboBox();
            operatorBindingSource = new BindingSource(components);
            tabJuristictions = new TabPage();
            JurisdictionDeleteButton = new Button();
            JurisdictionAddButton = new Button();
            jurisdictionComboBox = new ComboBox();
            jurisdictionBindingSource = new BindingSource(components);
            toolTipEventSave = new ToolTip(components);
            eventLog = new System.Diagnostics.EventLog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            btnDismiss = new Button();
            toolTip1 = new ToolTip(components);
            TabControlConfig.SuspendLayout();
            tabEvent.SuspendLayout();
            tabOperators.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)operatorBindingSource).BeginInit();
            tabJuristictions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)jurisdictionBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)eventLog).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TabControlConfig
            // 
            TabControlConfig.Controls.Add(tabEvent);
            TabControlConfig.Controls.Add(tabOperators);
            TabControlConfig.Controls.Add(tabJuristictions);
            TabControlConfig.Location = new Point(14, 14);
            TabControlConfig.Margin = new Padding(4, 3, 4, 3);
            TabControlConfig.Name = "TabControlConfig";
            TabControlConfig.SelectedIndex = 0;
            TabControlConfig.ShowToolTips = true;
            TabControlConfig.Size = new Size(500, 297);
            TabControlConfig.TabIndex = 0;
            TabControlConfig.SelectedIndexChanged += TabControlConfig_SelectedIndexChanged;
            // 
            // tabEvent
            // 
            tabEvent.BackColor = Color.PaleTurquoise;
            tabEvent.Controls.Add(btnEventSave);
            tabEvent.Controls.Add(label1);
            tabEvent.Controls.Add(txtBoxEvent);
            tabEvent.Location = new Point(4, 24);
            tabEvent.Margin = new Padding(4, 3, 4, 3);
            tabEvent.Name = "tabEvent";
            tabEvent.Padding = new Padding(4, 3, 4, 3);
            tabEvent.Size = new Size(492, 269);
            tabEvent.TabIndex = 2;
            tabEvent.Text = "Event";
            // 
            // btnEventSave
            // 
            btnEventSave.Location = new Point(371, 52);
            btnEventSave.Name = "btnEventSave";
            btnEventSave.Size = new Size(103, 23);
            btnEventSave.TabIndex = 2;
            btnEventSave.Text = "Save";
            toolTip1.SetToolTip(btnEventSave, "Save this Event to the database");
            btnEventSave.UseVisualStyleBackColor = true;
            btnEventSave.Click += btnEventSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 35);
            label1.Name = "label1";
            label1.Size = new Size(144, 15);
            label1.TabIndex = 1;
            label1.Text = "Address or Name of Event";
            // 
            // txtBoxEvent
            // 
            txtBoxEvent.Location = new Point(24, 53);
            txtBoxEvent.Margin = new Padding(4, 3, 4, 3);
            txtBoxEvent.Name = "txtBoxEvent";
            txtBoxEvent.Size = new Size(330, 23);
            txtBoxEvent.TabIndex = 0;
            // 
            // tabOperators
            // 
            tabOperators.BackColor = Color.Silver;
            tabOperators.Controls.Add(buttonDelete);
            tabOperators.Controls.Add(buttonAdd);
            tabOperators.Controls.Add(operatorComboBox);
            tabOperators.Location = new Point(4, 24);
            tabOperators.Margin = new Padding(4, 3, 4, 3);
            tabOperators.Name = "tabOperators";
            tabOperators.Padding = new Padding(4, 3, 4, 3);
            tabOperators.Size = new Size(492, 269);
            tabOperators.TabIndex = 0;
            tabOperators.Text = "Operators";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(233, 69);
            buttonDelete.Margin = new Padding(4, 3, 4, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(88, 27);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Delete";
            toolTip1.SetToolTip(buttonDelete, "Delete this operator from the database");
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += OperatorButtonDelete;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(233, 36);
            buttonAdd.Margin = new Padding(4, 3, 4, 3);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(88, 27);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Add";
            toolTip1.SetToolTip(buttonAdd, "Add a new operator to the database");
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += OperatorButtonAdd_Click;
            // 
            // operatorComboBox
            // 
            operatorComboBox.DataSource = operatorBindingSource;
            operatorComboBox.DisplayMember = "OperatorName";
            operatorComboBox.FormattingEnabled = true;
            operatorComboBox.Location = new Point(31, 36);
            operatorComboBox.Margin = new Padding(4, 3, 4, 3);
            operatorComboBox.Name = "operatorComboBox";
            operatorComboBox.Size = new Size(185, 23);
            operatorComboBox.TabIndex = 0;
            // 
            // operatorBindingSource
            // 
            operatorBindingSource.DataSource = typeof(Model.Operator);
            // 
            // tabJuristictions
            // 
            tabJuristictions.BackColor = Color.Khaki;
            tabJuristictions.Controls.Add(JurisdictionDeleteButton);
            tabJuristictions.Controls.Add(JurisdictionAddButton);
            tabJuristictions.Controls.Add(jurisdictionComboBox);
            tabJuristictions.Location = new Point(4, 24);
            tabJuristictions.Margin = new Padding(4, 3, 4, 3);
            tabJuristictions.Name = "tabJuristictions";
            tabJuristictions.Padding = new Padding(4, 3, 4, 3);
            tabJuristictions.Size = new Size(492, 269);
            tabJuristictions.TabIndex = 1;
            tabJuristictions.Text = "Jurisdictions";
            tabJuristictions.Click += tabJuristictions_Click;
            // 
            // JurisdictionDeleteButton
            // 
            JurisdictionDeleteButton.Location = new Point(233, 69);
            JurisdictionDeleteButton.Margin = new Padding(4, 3, 4, 3);
            JurisdictionDeleteButton.Name = "JurisdictionDeleteButton";
            JurisdictionDeleteButton.Size = new Size(88, 27);
            JurisdictionDeleteButton.TabIndex = 2;
            JurisdictionDeleteButton.Text = "Delete";
            toolTip1.SetToolTip(JurisdictionDeleteButton, "Delete this jurisdiction from the database");
            JurisdictionDeleteButton.UseVisualStyleBackColor = true;
            JurisdictionDeleteButton.Click += JurisdictionDeleteButton_Click;
            // 
            // JurisdictionAddButton
            // 
            JurisdictionAddButton.Location = new Point(233, 36);
            JurisdictionAddButton.Margin = new Padding(4, 3, 4, 3);
            JurisdictionAddButton.Name = "JurisdictionAddButton";
            JurisdictionAddButton.Size = new Size(88, 27);
            JurisdictionAddButton.TabIndex = 1;
            JurisdictionAddButton.Text = "Add";
            toolTip1.SetToolTip(JurisdictionAddButton, "Add this jurisdiction to the database");
            JurisdictionAddButton.UseVisualStyleBackColor = true;
            JurisdictionAddButton.Click += JurisdictionAddButton_Click;
            // 
            // jurisdictionComboBox
            // 
            jurisdictionComboBox.DataSource = jurisdictionBindingSource;
            jurisdictionComboBox.DisplayMember = "Jurisdiction1";
            jurisdictionComboBox.FormattingEnabled = true;
            jurisdictionComboBox.Location = new Point(31, 36);
            jurisdictionComboBox.Margin = new Padding(4, 3, 4, 3);
            jurisdictionComboBox.Name = "jurisdictionComboBox";
            jurisdictionComboBox.Size = new Size(185, 23);
            jurisdictionComboBox.TabIndex = 0;
            // 
            // jurisdictionBindingSource
            // 
            jurisdictionBindingSource.DataSource = typeof(Model.Jurisdiction);
            // 
            // toolTipEventSave
            // 
            toolTipEventSave.IsBalloon = true;
            toolTipEventSave.ToolTipIcon = ToolTipIcon.Info;
            toolTipEventSave.ToolTipTitle = "Save the Event to the Database";
            // 
            // eventLog
            // 
            eventLog.SynchronizingObject = this;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 314);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(599, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btnDismiss
            // 
            btnDismiss.DialogResult = DialogResult.OK;
            btnDismiss.Location = new Point(517, 38);
            btnDismiss.Name = "btnDismiss";
            btnDismiss.Size = new Size(55, 23);
            btnDismiss.TabIndex = 2;
            btnDismiss.Text = "Dismiss";
            toolTip1.SetToolTip(btnDismiss, "Dismiss this dialog box\r\n\r\n");
            btnDismiss.UseVisualStyleBackColor = true;
            btnDismiss.Click += button1_Click;
            // 
            // toolTip1
            // 
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "What dos this button do?";
            // 
            // Config
            // 
            AcceptButton = btnDismiss;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 336);
            ControlBox = false;
            Controls.Add(btnDismiss);
            Controls.Add(statusStrip1);
            Controls.Add(TabControlConfig);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Config";
            Text = "Application Configuration";
            TopMost = true;
            Load += Config_Load;
            TabControlConfig.ResumeLayout(false);
            tabEvent.ResumeLayout(false);
            tabEvent.PerformLayout();
            tabOperators.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)operatorBindingSource).EndInit();
            tabJuristictions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)jurisdictionBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)eventLog).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlConfig;
        private System.Windows.Forms.TabPage tabOperators;
        private System.Windows.Forms.TabPage tabJuristictions;
        private System.Windows.Forms.ComboBox operatorComboBox;
        private System.Windows.Forms.ComboBox jurisdictionComboBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button JurisdictionDeleteButton;
        private System.Windows.Forms.Button JurisdictionAddButton;
        private System.Windows.Forms.TabPage tabEvent;
        private System.Windows.Forms.TextBox txtBoxEvent;
        private Button btnEventSave;
        private Label label1;
        private ToolTip toolTipEventSave;
        private System.Diagnostics.EventLog eventLog;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button btnDismiss;
        private ToolTip toolTip1;
        private BindingSource operatorBindingSource;
        private BindingSource jurisdictionBindingSource;
    }
}