using Mybarber.DataTransferObject.Barbearia;
using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Repository
{
    public interface IBarbeariasRepository
    {
        //BARBEARIA
        Task<Barbearias[]> GetAllBarbeariasAsync();
        Task<Barbearias> GetBarbeariasAsyncById(Guid idBarbearia);
        Task<Barbearias> GetBarbeariasAsyncByIdDAO(Guid idBarbearia);
        Task<Barbearias> GetBarbeariasAsyncByRoute(string route);
       

    }
}
