using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IContatosServices
    {
        Task<Contatos> PostContatosAsync(Contatos contato);
    }
}
