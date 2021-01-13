using System.Net;
using System.Net.Mail;

namespace RedSky.Utilities
{
    public class Email
    {
        public static void Send(MailMessage msg, SmtpClient smtpServer)
        {
            // Forces the elimination of server certificate validation.
            ServicePointManager.ServerCertificateValidationCallback =
                (sender, certificate, chain, sslPolicyErrors) => true;
            try
            {
                smtpServer.Send(msg);
            }
            finally
            {
                msg.Dispose();
                smtpServer.Dispose();
            }
        }
    }
}