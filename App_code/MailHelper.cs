using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;

//MailHelper.SendMailMessage("fromAddress@yourdomain.com", "toAddress@yourdomain.com", "bccAddress@yourdomain.com", "ccAddress@yourdomain.com", "Sample Subject", "Sample body of text for mail message")

public class MailHelper
{
    /// <summary>
    /// Sends an mail message
    /// </summary>
    /// <param name="from">Sender address</param>
    /// <param name="to">Recepient address</param>
    /// <param name="bcc">Bcc recepient</param>
    /// <param name="cc">Cc recepient</param>
    /// <param name="subject">Subject of mail message</param>
    /// <param name="body">Body of mail message</param>
    public void SendMailMessage(string from, string to, string bcc, string cc, string subject, string body)
    {
        // Instantiate a new instance of MailMessage
        MailMessage mMailMessage = new MailMessage();

        // Set the sender address of the mail message
        mMailMessage.From = new MailAddress(from);
        // Set the recepient address of the mail message
        mMailMessage.To.Add(new MailAddress(to));

        // Check if the bcc value is null or an empty string
        if ((bcc != null) && (bcc != string.Empty))
        {
            // Set the Bcc address of the mail message
            mMailMessage.Bcc.Add(new MailAddress(bcc));
        }      // Check if the cc value is null or an empty value
        if ((cc != null) && (cc != string.Empty))
        {
            // Set the CC address of the mail message
            mMailMessage.CC.Add(new MailAddress(cc));
        }       // Set the subject of the mail message
        mMailMessage.Subject = subject;
        // Set the body of the mail message
        mMailMessage.Body = body;

        // Set the format of the mail message body as HTML
        mMailMessage.IsBodyHtml = true;
        // Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal;

        // Instantiate a new instance of SmtpClient
        SmtpClient mSmtpClient = new SmtpClient();

        mSmtpClient.Host = "secure.emailsrvr.com";
        mSmtpClient.Port = 25;
        mSmtpClient.UseDefaultCredentials = true;
        //mSmtpClient.Credentials = new System.Net.NetworkCredential("hris@vumobile.biz", "hris#@vuit");
        mSmtpClient.Credentials = new System.Net.NetworkCredential("hris@vumobile.biz", "hr@ISvu1#");
        //mSmtpClient.EnableSsl = true;

        // Send the mail message
        mSmtpClient.Send(mMailMessage);
    }
}
