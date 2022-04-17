using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repository
{
    public interface IBarbeirosRepository
    {
        //BARBEIROS
        //Task<Barbeiros[]> GetAllBarbeirosAsync();
        Task<Barbeiros> GetBarbeirosAsyncById(int idBarbeiro);
        Task<Barbeiros[]> GetBarbeirosAsyncByTenant(int idBarbearia);
        Task<Barbeiros> GetBarbeirosAsyncByEmail(string email);
    }
}
