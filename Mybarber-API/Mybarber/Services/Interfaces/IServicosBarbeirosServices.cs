using Mybarber.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IServicosBarbeirosServices
    {
        Task<ServicosBarbeiros> PostServicoBarbeirosAsync(ServicosBarbeiros servicosBarbeiros);
        Task<ServicosBarbeiros> PostServicoBarbeirosAsyncFromBarbeiro(ICollection<int> servicosId, Barbeiros barbeiro);

    }
}
