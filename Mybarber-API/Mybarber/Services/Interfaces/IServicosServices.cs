using Mybarber.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IServicosServices
    {
        //Task<IEnumerable<Servicos>> GetAllServicosAsync();
        Task<Servicos> GetServicoAsyncById(int idServico);

        Task<IEnumerable<Servicos>> GetServicoAsyncByTenant(int idBarbearia);
        Task<Servicos> PostServicoAsync(Servicos servicos);
        Task<string> DeleteServicoAsyncById(int idServico);
    }
}
