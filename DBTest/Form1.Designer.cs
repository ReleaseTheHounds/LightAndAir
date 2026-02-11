namespace DBTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            scannedTankBindingSource = new BindingSource(components);
            serialNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            hydrostatDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pressureDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            conditionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jurisdictionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            operatorNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scannedTankBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { serialNumberDataGridViewTextBoxColumn, hydrostatDateDataGridViewTextBoxColumn, pressureDataGridViewTextBoxColumn, conditionDataGridViewTextBoxColumn, jurisdictionDataGridViewTextBoxColumn, operatorNameDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
            dataGridView1.DataSource = scannedTankBindingSource;
            dataGridView1.Location = new Point(12, 77);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(743, 163);
            dataGridView1.TabIndex = 0;
            // 
            // scannedTankBindingSource
            // 
            scannedTankBindingSource.DataSource = typeof(Model.ScannedTank);
            // 
            // serialNumberDataGridViewTextBoxColumn
            // 
            serialNumberDataGridViewTextBoxColumn.DataPropertyName = "SerialNumber";
            serialNumberDataGridViewTextBoxColumn.HeaderText = "SerialNumber";
            serialNumberDataGridViewTextBoxColumn.Name = "serialNumberDataGridViewTextBoxColumn";
            // 
            // hydrostatDateDataGridViewTextBoxColumn
            // 
            hydrostatDateDataGridViewTextBoxColumn.DataPropertyName = "HydrostatDate";
            hydrostatDateDataGridViewTextBoxColumn.HeaderText = "HydrostatDate";
            hydrostatDateDataGridViewTextBoxColumn.Name = "hydrostatDateDataGridViewTextBoxColumn";
            // 
            // pressureDataGridViewTextBoxColumn
            // 
            pressureDataGridViewTextBoxColumn.DataPropertyName = "Pressure";
            pressureDataGridViewTextBoxColumn.HeaderText = "Pressure";
            pressureDataGridViewTextBoxColumn.Name = "pressureDataGridViewTextBoxColumn";
            // 
            // conditionDataGridViewTextBoxColumn
            // 
            conditionDataGridViewTextBoxColumn.DataPropertyName = "Condition";
            conditionDataGridViewTextBoxColumn.HeaderText = "Condition";
            conditionDataGridViewTextBoxColumn.Name = "conditionDataGridViewTextBoxColumn";
            // 
            // jurisdictionDataGridViewTextBoxColumn
            // 
            jurisdictionDataGridViewTextBoxColumn.DataPropertyName = "Jurisdiction";
            jurisdictionDataGridViewTextBoxColumn.HeaderText = "Jurisdiction";
            jurisdictionDataGridViewTextBoxColumn.Name = "jurisdictionDataGridViewTextBoxColumn";
            // 
            // operatorNameDataGridViewTextBoxColumn
            // 
            operatorNameDataGridViewTextBoxColumn.DataPropertyName = "OperatorName";
            operatorNameDataGridViewTextBoxColumn.HeaderText = "Operator";
            operatorNameDataGridViewTextBoxColumn.Name = "operatorNameDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Event";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)scannedTankBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hydrostatDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pressureDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn conditionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jurisdictionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn operatorNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private BindingSource scannedTankBindingSource;
    }
}
