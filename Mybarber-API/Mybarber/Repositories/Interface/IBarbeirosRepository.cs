using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Repository
{
    public interface IBarbeirosRepository
    {
        //BARBEIROS
        //Task<Barbeiros[]> GetAllBarbeirosAsync();
        Task<Barbeiros> GetBarbeirosAsyncById(Guid idBarbeiro);
        Task<Barbeiros[]> GetBarbeirosAsyncByTenant(Guid idBarbearia);
        Task<Barbeiros> GetBarbeirosAsyncByEmail(string email);
    }
}
