namespace SCBAlogger
{
    partial class CreateBarcode
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
            OkButton = new Button();
            BarcodeTextBox = new TextBox();
            BarcodeTextBoxTip = new ToolTip(components);
            label1 = new Label();
            BarcodeImage = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)BarcodeImage).BeginInit();
            SuspendLayout();
            // 
            // OkButton
            // 
            OkButton.DialogResult = DialogResult.OK;
            OkButton.Location = new Point(671, 263);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(87, 27);
            OkButton.TabIndex = 0;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            // 
            // BarcodeTextBox
            // 
            BarcodeTextBox.Location = new Point(193, 51);
            BarcodeTextBox.Name = "BarcodeTextBox";
            BarcodeTextBox.Size = new Size(315, 23);
            BarcodeTextBox.TabIndex = 1;
            BarcodeTextBox.PreviewKeyDown += BarcodeTextBox_PreviewKeyDown;
            // 
            // BarcodeTextBoxTip
            // 
            BarcodeTextBoxTip.ToolTipIcon = ToolTipIcon.Info;
            BarcodeTextBoxTip.ToolTipTitle = "Enter a barcode here and press enter";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 59);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 2;
            label1.Text = "Barcode Value";
            // 
            // BarcodeImage
            // 
            BarcodeImage.Location = new Point(193, 117);
            BarcodeImage.Name = "BarcodeImage";
            BarcodeImage.Size = new Size(429, 53);
            BarcodeImage.TabIndex = 3;
            BarcodeImage.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 117);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 4;
            label2.Text = "Barcode Image";
            // 
            // CreateBarcode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 302);
            Controls.Add(label2);
            Controls.Add(BarcodeImage);
            Controls.Add(label1);
            Controls.Add(BarcodeTextBox);
            Controls.Add(OkButton);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "CreateBarcode";
            Text = "Display a Barcode";
            Load += CreateBarcode_Load;
            ((System.ComponentModel.ISupportInitialize)BarcodeImage).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TextBox BarcodeTextBox;
        private System.Windows.Forms.ToolTip BarcodeTextBoxTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox BarcodeImage;
        private System.Windows.Forms.Label label2;
    }
}