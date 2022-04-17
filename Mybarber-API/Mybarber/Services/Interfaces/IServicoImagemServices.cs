using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IServicoImagemServices
    {
        Task<ServicoImagens> PostServicoImagemAsync(ServicoImagens imagem);
    }
}
