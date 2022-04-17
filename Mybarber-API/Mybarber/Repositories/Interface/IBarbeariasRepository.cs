using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repository
{
    public interface IBarbeariasRepository
    {
        //BARBEARIA
        Task<Barbearias[]> GetAllBarbeariasAsync();
        Task<Barbearias> GetBarbeariasAsyncById(int idBarbearia);


    }
}
