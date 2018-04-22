using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Hotel.Models;
using System.Web.Configuration;

namespace Hotel.Helpers
{
    public class EmailHelper
    {
        public void SendEmail(Reservation reserv, HttpServerUtilityBase server)
        {

            var from = WebConfigurationManager.AppSettings["emailFrom"];
            string to;
            var body = EmailBody(reserv, server);
            MailMessage message;
            // send copy to 
            if (!string.IsNullOrEmpty(reserv.Email))
            {
                to = reserv.Email;
                message = new MailMessage(from, to)
                {
                    Subject = "Резервування номеру.",
                    Body = body
                };
                SendEmail(from, to, message);
            }

            //send copy to administrator
            to = from;
            message = new MailMessage(from, to)
            {
                Subject = "Номер було зарезервовано",
                Body = body
            };
            SendEmail(from, to, message);
        }

        void SendEmail(string from, string to, MailMessage message)
        {
            var pass = WebConfigurationManager.AppSettings["emailPass"];
            var server = WebConfigurationManager.AppSettings["emailSmtp"];
            var port = WebConfigurationManager.AppSettings["emailPort"];

            SmtpClient client = new SmtpClient
            {
                Host = server,
                Port = Int32.Parse(port),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, pass),
                UseDefaultCredentials = false
            };


        }
        string EmailBody(Reservation reserv, HttpServerUtilityBase server)
        {
            string bodyFile = server.MapPath(@"~\EmailBody.txt");
            //string bodyFile = @"~\EmailBody.txt";
            if (File.Exists(bodyFile))
            {
                CultureInfo culture = new CultureInfo("uk-UA");
                var body = File.ReadAllText(bodyFile);
                body = body.Replace("{name}", string.IsNullOrEmpty(reserv.Name) ? "" : reserv.Name);
                body = body.Replace("{aptype}", string.IsNullOrEmpty(reserv.Apartment.Type.Name) ? "" : reserv.Apartment.Type.Name);
                body = body.Replace("{startDate}", reserv.StartDate == DateTime.MinValue ? "" : reserv.StartDate.ToString("D",culture));
                body = body.Replace("{endDate}", reserv.EndDate == DateTime.MinValue ? "" : reserv.EndDate.ToString("D", culture));
                body = body.Replace("{phone}", string.IsNullOrEmpty(reserv.PhoneNumber) ? "" : reserv.PhoneNumber);
                body = body.Replace("{note}", string.IsNullOrEmpty(reserv.Note) ? "" : reserv.Note);
                return body;
            }
            return string.Empty;
        }
    }
}