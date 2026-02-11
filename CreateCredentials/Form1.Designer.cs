namespace CreateCredentials
{
    partial class Form1
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
            saveButton = new Button();
            button2 = new Button();
            txtPassword = new TextBox();
            label1 = new Label();
            txtSecretName = new TextBox();
            label2 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Location = new Point(713, 29);
            saveButton.Margin = new Padding(4, 3, 4, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(91, 40);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(713, 75);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(91, 39);
            button2.TabIndex = 1;
            button2.Text = "Load";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnLoadSecret_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(218, 286);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(313, 23);
            txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(141, 286);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 3;
            label1.Text = "Password";
            // 
            // txtSecretName
            // 
            txtSecretName.Location = new Point(217, 206);
            txtSecretName.Margin = new Padding(4, 3, 4, 3);
            txtSecretName.Name = "txtSecretName";
            txtSecretName.Size = new Size(313, 23);
            txtSecretName.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(86, 206);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(112, 15);
            label2.TabIndex = 5;
            label2.Text = "Name of the Sercret";
            // 
            // txtName
            // 
            txtName.Location = new Point(217, 245);
            txtName.Name = "txtName";
            txtName.Size = new Size(314, 23);
            txtName.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(141, 245);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 7;
            label3.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(70, 60);
            label4.Name = "label4";
            label4.Size = new Size(612, 32);
            label4.TabIndex = 8;
            label4.Text = "Maintains the Password for any of the required Services.";
            label4.Click += label4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 479);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtSecretName);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(button2);
            Controls.Add(saveButton);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Service Password Maintenance";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSecretName;
        private System.Windows.Forms.Label label2;
        private TextBox txtName;
        private Label label3;
        private Label label4;
    }
}

