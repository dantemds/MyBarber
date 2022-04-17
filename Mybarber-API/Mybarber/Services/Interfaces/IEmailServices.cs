using Mybarber.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IEmailServices
    {
        void SendEmail(Agendamentos agendamentos, string tipoHtml);
        Task<Barbeiros> GetBarbeiroForEmail(int idBarbeiro);
        Task<Servicos> GetServicoForEmail(int idServico);
        
    }
}
