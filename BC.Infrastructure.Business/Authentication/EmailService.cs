using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BC.Infrastructure.Business.Authentication
{
    public class EmailService : IIdentityMessageService
    {
        private string confirmationLink;
        private string email;

        public EmailService(string email)
        {
            this.email = email;
        }

        public EmailService(string email, string confirmationLink) : this(email)
        {
            this.confirmationLink = confirmationLink;
        }

        public async Task SendAsync(IdentityMessage message)
        {
            await SendConfirmationEmailAsync(message, email, confirmationLink);
        }

        public async Task SendConfirmationEmailAsync(IdentityMessage message, string email, string confirmationLink)
        {
            var fromAddress = new MailAddress("dinastiadobra@gmail.com", "Dinastia Dobra");
            var toAddress = new MailAddress(email, "miko niko");

            string subject = "Confirm email";
            string body = "Please confirm your email... " + "< a href =\"" + confirmationLink + "\">here</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "MarkAndVladAngular2"),
                Timeout = 20000
            };

            using (var msg = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(msg);
            }
        }
    }
}
