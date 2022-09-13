using Mybarber.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IEmailServices
    {
        void SendEmail(Agendamentos agendamentos, string tipoHtml);
        Task<Barbeiros> GetBarbeiroForEmail(Guid idBarbeiro);
        Task<Servicos> GetServicoForEmail(Guid idServico);
        
    }
}
