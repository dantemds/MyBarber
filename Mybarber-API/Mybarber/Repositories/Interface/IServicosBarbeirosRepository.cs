using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public interface IServicosBarbeirosRepository
    {
        Task<ServicosBarbeiros> GetServicosBarbeirosAsyncByTenant(int idTenant);
    }
}
