using SCBAlogger.Model;

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
            label2 = new Label();
            buttonDelete = new Button();
            buttonAdd = new Button();
            operatorComboBox = new ComboBox();
            operatorBindingSource = new BindingSource(components);
            tabJuristictions = new TabPage();
            btnJurisdictionDeactivate = new Button();
            btnJurisdictionAdd = new Button();
            jurisdictionComboBox = new ComboBox();
            jurisdictionBindingSource = new BindingSource(components);
            tabCompressor = new TabPage();
            btnCompressorDeactivate = new Button();
            btnCompressorAdd = new Button();
            comboBox1 = new ComboBox();
            toolTipEventSave = new ToolTip(components);
            eventLog = new System.Diagnostics.EventLog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            btnDismiss = new Button();
            toolTip1 = new ToolTip(components);
            label3 = new Label();
            TabControlConfig.SuspendLayout();
            tabEvent.SuspendLayout();
            tabOperators.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)operatorBindingSource).BeginInit();
            tabJuristictions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)jurisdictionBindingSource).BeginInit();
            tabCompressor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)eventLog).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TabControlConfig
            // 
            TabControlConfig.Controls.Add(tabEvent);
            TabControlConfig.Controls.Add(tabOperators);
            TabControlConfig.Controls.Add(tabJuristictions);
            TabControlConfig.Controls.Add(tabCompressor);
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
            btnEventSave.Location = new Point(368, 36);
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
            label1.Location = new Point(24, 17);
            label1.Name = "label1";
            label1.Size = new Size(144, 15);
            label1.TabIndex = 1;
            label1.Text = "Address or Name of Event";
            // 
            // txtBoxEvent
            // 
            txtBoxEvent.Location = new Point(31, 36);
            txtBoxEvent.Margin = new Padding(4, 3, 4, 3);
            txtBoxEvent.Name = "txtBoxEvent";
            txtBoxEvent.Size = new Size(330, 23);
            txtBoxEvent.TabIndex = 0;
            // 
            // tabOperators
            // 
            tabOperators.BackColor = Color.Silver;
            tabOperators.Controls.Add(label2);
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
            toolTip1.SetToolTip(tabOperators, "Toggles that state of the selected operator. ");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 151);
            label2.MaximumSize = new Size(400, 500);
            label2.Name = "label2";
            label2.Size = new Size(395, 45);
            label2.TabIndex = 3;
            label2.Text = "Inactive Operators are shown as grayed out. Grayed out operators do not appear on the list of operators for active scanning. However, they may be re-activated by toggleing their active state.\r\n";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(233, 69);
            buttonDelete.Margin = new Padding(4, 3, 4, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(88, 41);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Toggle Active State";
            toolTip1.SetToolTip(buttonDelete, "Delete this operator from the database");
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += OperatorButtonInactivate;
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
            operatorBindingSource.DataSource = typeof(Operator);
            // 
            // tabJuristictions
            // 
            tabJuristictions.BackColor = Color.Khaki;
            tabJuristictions.Controls.Add(label3);
            tabJuristictions.Controls.Add(btnJurisdictionDeactivate);
            tabJuristictions.Controls.Add(btnJurisdictionAdd);
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
            // btnJurisdictionDeactivate
            // 
            btnJurisdictionDeactivate.Location = new Point(233, 69);
            btnJurisdictionDeactivate.Margin = new Padding(4, 3, 4, 3);
            btnJurisdictionDeactivate.Name = "btnJurisdictionDeactivate";
            btnJurisdictionDeactivate.Size = new Size(88, 43);
            btnJurisdictionDeactivate.TabIndex = 2;
            btnJurisdictionDeactivate.Text = "Toggle Active State";
            toolTip1.SetToolTip(btnJurisdictionDeactivate, "Deactive this jurisdiction from the database");
            btnJurisdictionDeactivate.UseVisualStyleBackColor = true;
            btnJurisdictionDeactivate.Click += JurisdictionDeleteButton_Click;
            // 
            // btnJurisdictionAdd
            // 
            btnJurisdictionAdd.Location = new Point(233, 36);
            btnJurisdictionAdd.Margin = new Padding(4, 3, 4, 3);
            btnJurisdictionAdd.Name = "btnJurisdictionAdd";
            btnJurisdictionAdd.Size = new Size(88, 27);
            btnJurisdictionAdd.TabIndex = 1;
            btnJurisdictionAdd.Text = "Add";
            toolTip1.SetToolTip(btnJurisdictionAdd, "Add this jurisdiction to the database");
            btnJurisdictionAdd.UseVisualStyleBackColor = true;
            btnJurisdictionAdd.Click += JurisdictionAddButton_Click;
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
            jurisdictionBindingSource.DataSource = typeof(Jurisdiction);
            // 
            // tabCompressor
            // 
            tabCompressor.BackColor = Color.PaleGreen;
            tabCompressor.Controls.Add(btnCompressorDeactivate);
            tabCompressor.Controls.Add(btnCompressorAdd);
            tabCompressor.Controls.Add(comboBox1);
            tabCompressor.Location = new Point(4, 24);
            tabCompressor.Name = "tabCompressor";
            tabCompressor.Padding = new Padding(3);
            tabCompressor.Size = new Size(492, 269);
            tabCompressor.TabIndex = 3;
            tabCompressor.Text = "Compressors";
            tabCompressor.ToolTipText = "Track the Compressors";
            // 
            // btnCompressorDeactivate
            // 
            btnCompressorDeactivate.Location = new Point(179, 65);
            btnCompressorDeactivate.Margin = new Padding(4, 3, 4, 3);
            btnCompressorDeactivate.Name = "btnCompressorDeactivate";
            btnCompressorDeactivate.Size = new Size(88, 27);
            btnCompressorDeactivate.TabIndex = 3;
            btnCompressorDeactivate.Text = "Delete";
            toolTip1.SetToolTip(btnCompressorDeactivate, "Deactivate this Compressor");
            btnCompressorDeactivate.UseVisualStyleBackColor = true;
            // 
            // btnCompressorAdd
            // 
            btnCompressorAdd.Location = new Point(179, 32);
            btnCompressorAdd.Margin = new Padding(4, 3, 4, 3);
            btnCompressorAdd.Name = "btnCompressorAdd";
            btnCompressorAdd.Size = new Size(88, 27);
            btnCompressorAdd.TabIndex = 2;
            btnCompressorAdd.Text = "Add";
            toolTip1.SetToolTip(btnCompressorAdd, "Add this jurisdiction to the database");
            btnCompressorAdd.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(31, 36);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 140);
            label3.MaximumSize = new Size(400, 500);
            label3.Name = "label3";
            label3.Size = new Size(400, 45);
            label3.TabIndex = 4;
            label3.Text = "Inactive Jurisdictions are shown as grayed out. Grayed out operators do not appear on the list of operators for active scanning. However, they may be re-activated by toggleing their active state.\r\n";
            label3.Click += label3_Click;
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
            tabOperators.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)operatorBindingSource).EndInit();
            tabJuristictions.ResumeLayout(false);
            tabJuristictions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)jurisdictionBindingSource).EndInit();
            tabCompressor.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnJurisdictionDeactivate;
        private System.Windows.Forms.Button btnJurisdictionAdd;
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
        private TabPage tabCompressor;
        private Button btnCompressorDeactivate;
        private Button btnCompressorAdd;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
    }
}