namespace SCBAlogger
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            configurationToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            scannerToolsToolStripMenuItem = new ToolStripMenuItem();
            createABarcodeToolStripMenuItem = new ToolStripMenuItem();
            programmingBarcodesToolStripMenuItem = new ToolStripMenuItem();
            dataToolStripMenuItem = new ToolStripMenuItem();
            CreateWorkBoolMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            sendWorkBookMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            applicationStatus = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            eventLog = new System.Diagnostics.EventLog();
            groupBox1 = new GroupBox();
            label4 = new Label();
            JurisdictionCombo = new ComboBox();
            label5 = new Label();
            comboBoxOperators = new ComboBox();
            operatorBindingSource = new BindingSource(components);
            labelPressure = new Label();
            groupBoxCondition = new GroupBox();
            radioButtonOssDate = new RadioButton();
            radioButtonOosDamage = new RadioButton();
            radioButtonGood = new RadioButton();
            pressureListbox = new ListBox();
            label2 = new Label();
            hydrostatText = new TextBox();
            label1 = new Label();
            serialNumberText = new TextBox();
            scannerData = new TextBox();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            labelScans = new Label();
            operatorBindingSource1 = new BindingSource(components);
            jurisdictionBindingSource = new BindingSource(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)eventLog).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)operatorBindingSource).BeginInit();
            groupBoxCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)operatorBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jurisdictionBindingSource).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, scannerToolsToolStripMenuItem, dataToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1029, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configurationToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.Size = new Size(148, 22);
            configurationToolStripMenuItem.Text = "&Configuration";
            configurationToolStripMenuItem.Click += ConfigurationToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(148, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // scannerToolsToolStripMenuItem
            // 
            scannerToolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createABarcodeToolStripMenuItem, programmingBarcodesToolStripMenuItem });
            scannerToolsToolStripMenuItem.Name = "scannerToolsToolStripMenuItem";
            scannerToolsToolStripMenuItem.Size = new Size(91, 20);
            scannerToolsToolStripMenuItem.Text = "Scanner Tools";
            // 
            // createABarcodeToolStripMenuItem
            // 
            createABarcodeToolStripMenuItem.Name = "createABarcodeToolStripMenuItem";
            createABarcodeToolStripMenuItem.Size = new Size(199, 22);
            createABarcodeToolStripMenuItem.Text = "&Create a barcode";
            createABarcodeToolStripMenuItem.Click += CreateABarcodeToolStripMenuItem_Click;
            // 
            // programmingBarcodesToolStripMenuItem
            // 
            programmingBarcodesToolStripMenuItem.Name = "programmingBarcodesToolStripMenuItem";
            programmingBarcodesToolStripMenuItem.Size = new Size(199, 22);
            programmingBarcodesToolStripMenuItem.Text = "&Programming Barcodes";
            // 
            // dataToolStripMenuItem
            // 
            dataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CreateWorkBoolMenuItem, viewToolStripMenuItem, sendWorkBookMenuItem });
            dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            dataToolStripMenuItem.Size = new Size(43, 20);
            dataToolStripMenuItem.Text = "&Data";
            // 
            // CreateWorkBoolMenuItem
            // 
            CreateWorkBoolMenuItem.Name = "CreateWorkBoolMenuItem";
            CreateWorkBoolMenuItem.Size = new Size(168, 22);
            CreateWorkBoolMenuItem.Text = "CreateWorkbooks";
            CreateWorkBoolMenuItem.Click += Create_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(168, 22);
            viewToolStripMenuItem.Text = "&View";
            viewToolStripMenuItem.Click += Email_Click;
            // 
            // sendWorkBookMenuItem
            // 
            sendWorkBookMenuItem.Name = "sendWorkBookMenuItem";
            sendWorkBookMenuItem.Size = new Size(168, 22);
            sendWorkBookMenuItem.Text = "SendWorkbooks";
            sendWorkBookMenuItem.Click += Email_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            helpToolStripMenuItem.Click += HelpToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(32, 32);
            statusStrip1.Items.AddRange(new ToolStripItem[] { applicationStatus, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 532);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1029, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // applicationStatus
            // 
            applicationStatus.BackColor = Color.IndianRed;
            applicationStatus.ForeColor = Color.Black;
            applicationStatus.Name = "applicationStatus";
            applicationStatus.Size = new Size(92, 17);
            applicationStatus.Tag = "Perform Required Action";
            applicationStatus.Text = "Configure Event";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(0, 17);
            // 
            // eventLog
            // 
            eventLog.SynchronizingObject = this;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(JurisdictionCombo);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(comboBoxOperators);
            groupBox1.Controls.Add(labelPressure);
            groupBox1.Controls.Add(groupBoxCondition);
            groupBox1.Controls.Add(pressureListbox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(hydrostatText);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(serialNumberText);
            groupBox1.Location = new Point(28, 132);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(369, 393);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crurent Bottle";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 240);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 15;
            label4.Text = "Jurisdiction";
            // 
            // JurisdictionCombo
            // 
            JurisdictionCombo.DataSource = jurisdictionBindingSource;
            JurisdictionCombo.DisplayMember = "Name";
            JurisdictionCombo.FormattingEnabled = true;
            JurisdictionCombo.Location = new Point(110, 237);
            JurisdictionCombo.Name = "JurisdictionCombo";
            JurisdictionCombo.Size = new Size(121, 23);
            JurisdictionCombo.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 187);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 13;
            label5.Text = "Operator";
            // 
            // comboBoxOperators
            // 
            comboBoxOperators.DataSource = operatorBindingSource;
            comboBoxOperators.DisplayMember = "OperatorName";
            comboBoxOperators.FormattingEnabled = true;
            comboBoxOperators.Location = new Point(112, 187);
            comboBoxOperators.Name = "comboBoxOperators";
            comboBoxOperators.Size = new Size(121, 23);
            comboBoxOperators.TabIndex = 12;
            // 
            // operatorBindingSource
            // 
            operatorBindingSource.DataSource = typeof(Model.Operator);
            // 
            // labelPressure
            // 
            labelPressure.AutoSize = true;
            labelPressure.Location = new Point(13, 129);
            labelPressure.Name = "labelPressure";
            labelPressure.Size = new Size(51, 15);
            labelPressure.TabIndex = 10;
            labelPressure.Text = "Pressure";
            // 
            // groupBoxCondition
            // 
            groupBoxCondition.Controls.Add(radioButtonOssDate);
            groupBoxCondition.Controls.Add(radioButtonOosDamage);
            groupBoxCondition.Controls.Add(radioButtonGood);
            groupBoxCondition.Location = new Point(10, 324);
            groupBoxCondition.Margin = new Padding(4, 3, 4, 3);
            groupBoxCondition.Name = "groupBoxCondition";
            groupBoxCondition.Padding = new Padding(4, 3, 4, 3);
            groupBoxCondition.Size = new Size(338, 58);
            groupBoxCondition.TabIndex = 9;
            groupBoxCondition.TabStop = false;
            groupBoxCondition.Text = "Condition";
            // 
            // radioButtonOssDate
            // 
            radioButtonOssDate.AutoSize = true;
            radioButtonOssDate.Location = new Point(216, 29);
            radioButtonOssDate.Margin = new Padding(4, 3, 4, 3);
            radioButtonOssDate.Name = "radioButtonOssDate";
            radioButtonOssDate.Size = new Size(72, 19);
            radioButtonOssDate.TabIndex = 8;
            radioButtonOssDate.TabStop = true;
            radioButtonOssDate.Text = "Bad Date";
            radioButtonOssDate.UseVisualStyleBackColor = true;
            // 
            // radioButtonOosDamage
            // 
            radioButtonOosDamage.AutoSize = true;
            radioButtonOosDamage.Location = new Point(102, 29);
            radioButtonOosDamage.Margin = new Padding(4, 3, 4, 3);
            radioButtonOosDamage.Name = "radioButtonOosDamage";
            radioButtonOosDamage.Size = new Size(92, 19);
            radioButtonOosDamage.TabIndex = 7;
            radioButtonOosDamage.TabStop = true;
            radioButtonOosDamage.Text = "Bad Damage";
            radioButtonOosDamage.UseVisualStyleBackColor = true;
            // 
            // radioButtonGood
            // 
            radioButtonGood.AutoSize = true;
            radioButtonGood.Location = new Point(21, 29);
            radioButtonGood.Margin = new Padding(4, 3, 4, 3);
            radioButtonGood.Name = "radioButtonGood";
            radioButtonGood.Size = new Size(54, 19);
            radioButtonGood.TabIndex = 6;
            radioButtonGood.TabStop = true;
            radioButtonGood.Text = "Good";
            radioButtonGood.UseVisualStyleBackColor = true;
            // 
            // pressureListbox
            // 
            pressureListbox.FormattingEnabled = true;
            pressureListbox.Location = new Point(112, 129);
            pressureListbox.Margin = new Padding(4, 3, 4, 3);
            pressureListbox.Name = "pressureListbox";
            pressureListbox.Size = new Size(139, 34);
            pressureListbox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 87);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 3;
            label2.Text = "Hydrostat Date";
            label2.Click += label2_Click;
            // 
            // hydrostatText
            // 
            hydrostatText.Location = new Point(112, 87);
            hydrostatText.Margin = new Padding(4, 3, 4, 3);
            hydrostatText.Name = "hydrostatText";
            hydrostatText.ReadOnly = true;
            hydrostatText.Size = new Size(116, 23);
            hydrostatText.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 43);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 1;
            label1.Text = "BarCode";
            // 
            // serialNumberText
            // 
            serialNumberText.Location = new Point(112, 40);
            serialNumberText.Margin = new Padding(4, 3, 4, 3);
            serialNumberText.Name = "serialNumberText";
            serialNumberText.ReadOnly = true;
            serialNumberText.Size = new Size(221, 23);
            serialNumberText.TabIndex = 0;
            // 
            // scannerData
            // 
            scannerData.Location = new Point(28, 84);
            scannerData.Margin = new Padding(4, 3, 4, 3);
            scannerData.MaxLength = 30;
            scannerData.Name = "scannerData";
            scannerData.Size = new Size(388, 23);
            scannerData.TabIndex = 1;
            scannerData.PreviewKeyDown += ScannerData_PreviewKeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 52);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(143, 25);
            label3.TabIndex = 3;
            label3.Text = "Barcode Data";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(414, 161);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(447, 332);
            dataGridView1.TabIndex = 4;
            // 
            // labelScans
            // 
            labelScans.AutoSize = true;
            labelScans.BackColor = SystemColors.Highlight;
            labelScans.ForeColor = SystemColors.ControlLightLight;
            labelScans.Location = new Point(414, 132);
            labelScans.Margin = new Padding(4, 0, 4, 0);
            labelScans.Name = "labelScans";
            labelScans.Size = new Size(169, 15);
            labelScans.TabIndex = 5;
            labelScans.Text = "waiting for event identification";
            // 
            // operatorBindingSource1
            // 
            operatorBindingSource1.DataSource = typeof(Model.Operator);
            // 
            // jurisdictionBindingSource
            // 
            jurisdictionBindingSource.DataSource = typeof(Model.Jurisdiction);
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 554);
            Controls.Add(labelScans);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(scannerData);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Main";
            Load += Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)eventLog).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)operatorBindingSource).EndInit();
            groupBoxCondition.ResumeLayout(false);
            groupBoxCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)operatorBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)jurisdictionBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateWorkBoolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel applicationStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Diagnostics.EventLog eventLog;
        private System.Windows.Forms.ToolStripMenuItem scannerToolsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hydrostatText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serialNumberText;
        private System.Windows.Forms.TextBox scannerData;
        private System.Windows.Forms.ToolStripMenuItem createABarcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programmingBarcodesToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox pressureListbox;
        private System.Windows.Forms.RadioButton radioButtonOosDamage;
        private System.Windows.Forms.RadioButton radioButtonGood;
        private System.Windows.Forms.RadioButton radioButtonOssDate;
        private System.Windows.Forms.GroupBox groupBoxCondition;
        private System.Windows.Forms.Label labelScans;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ToolStripMenuItem sendWorkBookMenuItem;
        private Label label5;
        private ComboBox comboBoxOperators;
        private BindingSource operatorBindingSource;
        private Label labelPressure;
        private BindingSource operatorBindingSource1;
        private Label label4;
        private ComboBox JurisdictionCombo;
        private BindingSource jurisdictionBindingSource;
    }
}

