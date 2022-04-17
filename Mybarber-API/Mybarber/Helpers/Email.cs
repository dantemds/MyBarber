using Microsoft.Extensions.Configuration;
using Mybarber.Exceptions;
using Mybarber.Helpers.ToRead;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Mybarber.Helpers
{
    public static class Email
    {
        public static void Send(string email, string body, string subtitle, List<string> credentials)
        {
            try
            {
                
                MailMessage mailMessage = new MailMessage();
                var smtpCliente = new SmtpClient("smtp.titan.email", 587);
                smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpCliente.Timeout = 400 * 400;
                smtpCliente.UseDefaultCredentials = false;
                string e = credentials[0];
                string k = credentials[1];
                smtpCliente.Credentials = new NetworkCredential(e, k);
                smtpCliente.EnableSsl = true;

                mailMessage.From = new MailAddress(e, "Minha Barbearia");








                mailMessage.Body = body;


                mailMessage.Subject = subtitle;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.Normal;
                mailMessage.To.Add(email);
                smtpCliente.Send(mailMessage);

            } catch (Exception ex)
            { throw new Exception(ex.Message); }

        }

        public static string CreateBody(string name, string servico, string barbeiro, DateTime horario, string nomeBarbearia, string tipoHtml)
        {


            string html = ReadEmailAgendamento.GetHTMLAgendamento(tipoHtml, name, servico, barbeiro, horario, nomeBarbearia);


            return html;




            //string body = String.Empty;

            //using (var client = new WebClient())
            //{
            //    body = client.DownloadString("https://resultadosdigitais.com.br/especiais/landing-page/");

            //}
            //return body;

            //try
            //{
            //    string body = string.Empty;
            //    using (StreamReader reader = new StreamReader("EmailTemplate.razor"))
            //    {
            //        body = reader.ReadToEnd();
            //    }




            //    return body;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

        }



       public static string CreateSubtitle(string tipoHtml) 
        {

            
        switch (tipoHtml)

            {
                
                case  "EmailAgendamento":

                string subtitle = "Agendamento Realizado";

                    return subtitle;



                case "EmailCancelamento":

                 subtitle = "Agendamento Cancelado";

                    return subtitle;






            }
            throw new ViewException("Impossible.Get.Subtitle");
        
        }
    }
}
