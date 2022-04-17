using Microsoft.Extensions.Configuration;
using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly IServicosServices _repoServico;
        private readonly IBarbeirosServices _repoBarbeiro;
        private readonly IConfiguration _config;
        //private readonly IHTMLRepository _repoHTML;
        public EmailServices(IServicosServices repoServico, IBarbeirosServices repoBarbeiro, IConfiguration config) { 
            this._repoBarbeiro = repoBarbeiro;
            this._config = config;
            this._repoServico = repoServico;

        }

        public async Task<Servicos> GetServicoForEmail(int idServico)
        {
            var Servico = await  _repoServico.GetServicoAsyncById(idServico);

            return Servico;


        }

        public async Task<Barbeiros> GetBarbeiroForEmail(int idBarbeiro)
        {
            var Barbeiro = await _repoBarbeiro.GetBarbeiroAsyncById(idBarbeiro);

            return Barbeiro;
        }

       private  List<string> GetCredencials()
        {
            string email =  _config.GetSection("Key:Email").Value;
            string key = _config.GetSection("Key:KeyEmail").Value;
            List<string> credencials = new List<string>();
            credencials.Add(email);
            credencials.Add(key);
            return credencials;
        }

        public void SendEmail(Agendamentos agendamentos, string tipoHtml)
        {
            try { 
            var nomeBarbeiro = GetBarbeiroForEmail(agendamentos.BarbeirosId).Result.NameBarbeiro;

            var nomeServico =  GetServicoForEmail(agendamentos.ServicosId).Result.NomeServico;

            var nomeBarbearia = GetBarbeiroForEmail(agendamentos.BarbeirosId).Result.Barbearias.NomeBarbearia;

            List<string> credencials = GetCredencials();

               


                
            Email.Send(agendamentos.Email, Email.CreateBody(agendamentos.Name, nomeServico, nomeBarbeiro, agendamentos.Horario,nomeBarbearia, tipoHtml), Email.CreateSubtitle(tipoHtml),credencials);
        }catch(Exception ex)
            { throw new Exception(ex.Message); }
        
        
        
        }

    }
}
