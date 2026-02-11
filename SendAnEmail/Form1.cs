using CredentialManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SendAnEmail
{

     
    public partial class Form1 : Form
    {
        private const string CredentialTarget = "AirSecret";
        public Form1()
        {
            InitializeComponent();
        }


        // Retrieve a password from the local Windows Credential Manager
        private string RetrieveCredentials()
        {
            var cred = new Credential();
            cred.Target= CredentialTarget;
            
                if (cred.Load())
                {
                    return cred.Password;
                }
                else
                {
                    MessageBox.Show("No secret found.");
                    return String.Empty;
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string credTxt = RetrieveCredentials();
            SmtpClient client = new SmtpClient(
                Properties.Settings.Default.MailHost, 
                Properties.Settings.Default.MailHostPort
                );   
           

            //Authentication.
            //This is where the valid email account comes into play. You must have a valid email account(with password) to give our program a place to send the mail from.

            NetworkCredential cred = new NetworkCredential(Properties.Settings.Default.SendingUserName, RetrieveCredentials());
           
            //To send an email we must first create a new mailMessage(an email) to send.
            MailMessage Msg = new MailMessage();

            // Sender e-mail address.
            Msg.From = new MailAddress(Properties.Settings.Default.SendingUserName);

            // Recipient e-mail address.
            Msg.To.Add(Properties.Settings.Default.DestinationEmailAddress);

            // Assign the subject of our message.
            Msg.Subject = "SCBALogger Test Email";

            // Create the content(body) of our message.
            Msg.Body = "This wiil be replaced with the headder text and an attachment";

            // Send our account login details to the client.
            client.Credentials = cred;
            

            //Enabling SSL(Secure Sockets Layer, encyription) is reqiured by most email providers to send mail
            //client.EnableSsl = true;

            //Confirmation After Click the Button
            //label5.Text = "Mail Sended Succesfully";

            // Send our email.
            try
            {
                client.Send(Msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); 
            }
        



        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Create the email
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("gcoxjr@hotmail.com");
                mail.To.Add("gcoxjr@hotmail.com");
                mail.Subject = "Test Email from WinForms";
                mail.Body = "Hello! This is a test email sent from a C# Windows Forms app using Outlook.com SMTP.";

                // Configure SMTP client
                SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
                smtp.Credentials = new NetworkCredential("gcoxjr@hotmail.com", "Picard#1nurg1ze");
                smtp.EnableSsl = true;
                smtp.Timeout = (15000); // wait1 5 seconds
                // Send the email
                smtp.Send(mail);

                MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Credential cred;
            try
            {
                cred = new Credential { Target = "AirSecret" };
                
                    if (cred.Load())

                        MessageBox.Show($"Retrieved secret: {cred.Password}");
                    else
                        MessageBox.Show("No secret found.");
                
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("lightair1500@gmail.com");
                mail.To.Add("gcoxjr@hotmail.com");
                mail.Subject = "Test Email from C#";
                mail.Body = "Hello! This is a test email sent from a Windows Forms app.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("lightair1500@gmail.com", cred.Password);
                smtp.EnableSsl = true;
                smtp.Timeout = 10000;
                smtp.Send(mail);
                MessageBox.Show("Email sent successfully!");
                cred.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    

   
}
