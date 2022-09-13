using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public interface IServicosBarbeirosRepository
    {
        Task<ServicosBarbeiros> GetServicosBarbeirosAsyncByTenant(Guid idTenant);
    }
}
