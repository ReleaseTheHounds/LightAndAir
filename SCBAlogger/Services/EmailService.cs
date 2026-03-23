using System;
using System.Collections.Generic;
using System.Text;

namespace SCBAlogger.Services
{
    internal class EmailService
    {
        //string secretProperty = Settings.Default.EmailSecretName;
        //string txtPassword;
        //string txtAccountName;
        //NetworkCredential emailCredential;

        //var cred = CredentialManager.GetCredentials(secretProperty);


        //if (cred != null)
        //{
        //    txtPassword = cred.Password;
        //    txtAccountName = cred.UserName;

        //    emailCredential = new NetworkCredential(txtAccountName, txtPassword);
        //    WindowsLog.WriteLogEntry(EventLogEntryType.Information, $"Retrieved the secret for {secretProperty}", 20002);
        //}
        //else
        //{
        //    MessageBox.Show("No secret found.");
        //    WindowsLog.WriteLogEntry(EventLogEntryType.Error, $"No secret found for {secretProperty}", 2003);
        //    return;
        //}

        //MimeMessage msg = new MimeMessage();
        //msg.From.Add(new MailboxAddress(txtAccountName, $"{txtAccountName} @gmail.com"));

        //var addresses = Settings.Default.DestinationEmailAddresses.Split(',', StringSplitOptions.RemoveEmptyEntries);
        //foreach (string name in addresses)
        //{
        //    String txtName = name.Split("@")[0];
        //    msg.To.Add(new MailboxAddress(txtName, name));
        //}

        //msg.Subject = "AirSpreadsheets";
        //var body = new TextPart("plain")
        //{
        //    Text = "Please find attached the latest batch of SCBA fill workbooks/spreadsheets."
        //};

        //var attachmentPath = @"C:\temp\ScansFebruary2026.xlsx";
        //var attachment = new MimePart("application", "xlsx")
        //{
        //    Content = new MimeContent(File.OpenRead(attachmentPath)),
        //    ContentDescription = ContentDisposition.Attachment,
        //    ContentTransferEncoding = ContentEncoding.Base64,
        //    FileName = Path.GetFileName(attachmentPath)
        //};

        //var multipart = new Multipart("mixed");
        //multipart.Add(body);
        //multipart.Add(attachment);
        //msg.Body = multipart;

        //using (var client = new SmtpClient())
        //{
        //    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

        //    // Use App Password (not your regular Gmail password)
        //    client.Authenticate(txtAccountName, txtPassword);

        //    client.Send(msg);
        //    client.Disconnect(true);
        //}
    }
}
