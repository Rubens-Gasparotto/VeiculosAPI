using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace VeiculosAPI.Core.Email
{
    public class Email
    {
        private readonly IConfigurationSection config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SMTP");
        private readonly SmtpClient smtpClient;
        private readonly MailMessage mailMessage = new();
        public Email()
        {
            smtpClient = new(config["Server"], int.Parse(config["Port"]));
            smtpClient.Credentials = new NetworkCredential(config["Username"], config["Password"]);
            smtpClient.EnableSsl = true;

            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress(config["FromMail"], config["FromName"]);
        }

        public void Send(string subject, string destination, string body)
        {
            mailMessage.Subject = subject;
            mailMessage.To.Add(destination);
            mailMessage.Body = body;

            smtpClient.Send(mailMessage);
        }
    }
}
