using MesWebApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MesWebApi.Services
{
    public class EmailSender
    {
        private readonly IConfigurationRoot _config;
        public void Send(Message message)
        {
            MailMessage email = new MailMessage(_config["login"],message.Email);
            email.Subject = message.Title;
            email.Body = $"<b>This message from API</b></br>{message.Text}";
            SmtpClient client = new SmtpClient(_config["server:adress"],
                int.Parse(_config["server:port"]));

            client.Credentials = new NetworkCredential(_config["login"], _config["password"]);
            client.EnableSsl = true;
            client.Send(email);



        }
        public EmailSender(IConfigurationRoot config) 
        {
            _config = config;
        }
    }
}
