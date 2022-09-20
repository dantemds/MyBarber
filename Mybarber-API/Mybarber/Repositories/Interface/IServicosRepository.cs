using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Repository
{
    public interface IServicosRepository
    {


        //SERVIÇOS
        //Task<Servicos[]> GetAllServicosAsync();
        Task<Servicos> GetServicosAsyncById(Guid idServico);
        Task<Servicos[]> GetServicosAsyncByTenant(Guid idBarbearia);


    }
}
