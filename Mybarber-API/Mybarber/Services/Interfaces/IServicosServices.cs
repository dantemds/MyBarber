using Mybarber.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IServicosServices
    {
        //Task<IEnumerable<Servicos>> GetAllServicosAsync();
        Task<Servicos> GetServicoAsyncById(Guid idServico);

        Task<IEnumerable<Servicos>> GetServicoAsyncByTenant(Guid idBarbearia);
        Task<Servicos> PostServicoAsync(Servicos servicos);
        Task<Servicos> DeleteServicoAsyncById(Guid idServico);
    }
}
