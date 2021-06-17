﻿using SpicyX.Application.DataTransfer;
using SpicyX.Application.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SpicyX.Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly string _fromEmail;
        private readonly string _emailPassword;

        public SmtpEmailSender(string fromEmail, string emailPassword)
        {
            _fromEmail = fromEmail;
            _emailPassword = emailPassword;
        }
        public void Send(SendEmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromEmail, _emailPassword)
            };

            var message = new MailMessage(_fromEmail, dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
