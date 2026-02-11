using CredentialManagement;
using System.Diagnostics;

namespace CreateCredentials
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        const string SCBALogger = "SCBALogger";

        public Form1()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var cred = new Credential())
            {
                cred.Target = txtSecretName.Text;
                cred.Username = txtName.Text;
                cred.Password = txtPassword.Text; // Your secret string
                cred.Type = CredentialType.Generic;
                cred.PersistanceType = PersistanceType.LocalComputer;
                if (cred.Save())
                {
                    MessageBox.Show("Secret saved securely!");
                    EventLog.WriteEntry(SCBALogger, $"New secret saved for {txtSecretName.Text}", EventLogEntryType.Information, 20000, 1);
                }
                else
                {
                    MessageBox.Show("Failed to save secret.");
                    EventLog.WriteEntry(SCBALogger, $"Failed to saved a secret for {txtSecretName.Text}", EventLogEntryType.Error, 20001, 1);
                }

            }
        }

        private void btnLoadSecret_Click(object sender, EventArgs e)
        {
            using (var cred = new Credential { Target = txtSecretName.Text })
            {
                if (cred.Load())
                {
                    MessageBox.Show($"Retrieved secret: {cred.Password}");
                    EventLog.WriteEntry(SCBALogger, $"Retrieved the secret for {txtSecretName.Text}", EventLogEntryType.Information, 20002, 1);
                    txtPassword.Text = cred.Password;
                    txtName.Text = cred.Username;
                    txtSecretName.Text = cred.Target;
                }
                else
                {
                    MessageBox.Show("No secret found.");
                    EventLog.WriteEntry(SCBALogger, $"No secret found for {txtSecretName.Text}", EventLogEntryType.Warning, 20003, 1);

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
