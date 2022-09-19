using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IEnderecosServices
    {
        Task<Enderecos> PostEnderecoAsync(Enderecos endereco);
    }
}
