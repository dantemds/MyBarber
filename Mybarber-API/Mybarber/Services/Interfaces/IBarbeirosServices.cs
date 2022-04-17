using Mybarber.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IBarbeirosServices
    {
        //Task<IEnumerable<Barbeiros>> GetAllBarbeirosAsync();
        Task<Barbeiros> GetBarbeiroAsyncById(int idBarbeiro);
        Task<IEnumerable<Barbeiros>> GetBarbeiroAsyncByTenant(int idBarbearia);
        Task<Barbeiros> PostBarbeiroAsync(Barbeiros barbeiros);
        Task<string> DeleteBarbeiroAsyncById(int idBarbeiro);
        Task<bool> UpdateBarbeiroAsyncById(int idBarbeiro);
    }
}
