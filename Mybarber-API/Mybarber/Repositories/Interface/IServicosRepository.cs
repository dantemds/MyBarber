using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repository
{
    public interface IServicosRepository
    {


        //SERVIÇOS
        //Task<Servicos[]> GetAllServicosAsync();
        Task<Servicos> GetServicosAsyncById(int idServico);
        Task<Servicos[]> GetServicosAsyncByTenant(int idBarbearia);


    }
}
