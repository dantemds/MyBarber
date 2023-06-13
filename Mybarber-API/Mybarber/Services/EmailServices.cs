using Microsoft.Extensions.Configuration;
using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Mybarber.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly IServicosServices _repoServico;
        private readonly IBarbeirosServices _repoBarbeiro;
        private readonly IConfiguration _config;
       

        //private readonly IHTMLRepository _repoHTML;
        public EmailServices(IServicosServices repoServico, IBarbeirosServices repoBarbeiro, IConfiguration config)
        {
            this._repoBarbeiro = repoBarbeiro;
            this._config = config;
            this._repoServico = repoServico;

        }

        public async Task<Servicos> GetServicoForEmail(Guid idServico)
        {
            var Servico = await _repoServico.GetServicoAsyncById(idServico);

            return Servico;


        }

        public async Task<Barbeiros> GetBarbeiroForEmail(Guid idBarbeiro)
        {
            var Barbeiro = await _repoBarbeiro.GetBarbeiroAsyncById(idBarbeiro);

            return Barbeiro;
        }

        private List<string> GetCredencials()
        {
            string email = _config.GetSection("Key:Email").Value;
            string key = _config.GetSection("Key:KeyEmail").Value;
            List<string> credencials = new List<string>();
            credencials.Add(email);
            credencials.Add(key);
            return credencials;
        }

        public void SendEmail(Agendamentos agendamentos, string tipoHtml)
        {
            try
            {
                var nomeBarbeiro = GetBarbeiroForEmail(agendamentos.BarbeirosId).Result.NameBarbeiro;

                var nomeServico = GetServicoForEmail(agendamentos.ServicosId).Result.NomeServico;

                var nomeBarbearia = GetBarbeiroForEmail(agendamentos.BarbeirosId).Result.Barbearias.NomeBarbearia;

                List<string> credencials = GetCredencials();

                Email.Send(agendamentos.Email, Email.CreateBody(agendamentos.Name, nomeServico, nomeBarbeiro, agendamentos.Horario, nomeBarbearia, tipoHtml), Email.CreateSubtitle(tipoHtml), credencials);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
        public void SendSESEMail(Agendamentos agendamento, string tipoHtml, string destino = null)
        {
            // create message
            string to = agendamento.Email;

            if (destino != null)
            {
                to = destino.ToString();
            }

            var nomeBarbeiro = GetBarbeiroForEmail(agendamento.BarbeirosId).Result.NameBarbeiro;

            var nomeServico = GetServicoForEmail(agendamento.ServicosId).Result.NomeServico;

            var nomeBarbearia = GetBarbeiroForEmail(agendamento.BarbeirosId).Result.Barbearias.NomeBarbearia;

            string html = Email.CreateBody(agendamento.Name, nomeServico, nomeBarbeiro, agendamento.Horario, nomeBarbearia, tipoHtml);

            string subject = Email.CreateSubtitle(tipoHtml);

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("Key:Email").Value));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("Key:SmtpHost").Value, Convert.ToInt32(_config.GetSection("Key:SmtpPort").Value), SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("Key:SmtpUser").Value, _config.GetSection("Key:SmtpPass").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

    }
}

    

