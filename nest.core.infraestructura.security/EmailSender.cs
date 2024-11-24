using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace nest.core.infraestructura.security
{
    public class EmailSender : IEmailSender
    {
        private readonly string smtpServer;
        private readonly int port;
        private readonly string userName;
        private readonly string password;
        private readonly string from;
        private readonly string fromDisplay;


        public EmailSender(string smtpServer, int port, string userName, string password, string from, string fromDisplay)
        {
            this.smtpServer = smtpServer;
            this.port = port;
            this.userName = userName;
            this.password = password;
            this.from = from;
            this.fromDisplay = fromDisplay;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(this.fromDisplay, this.from));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = subject;
            message.Body = new TextPart("html")
            {
                Text = htmlMessage
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(this.from, "your_oauth2_access_token");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            Console.WriteLine("Correo enviado exitosamente.");
        }
    }
}
