using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IBarbeiroImagemServices
    {

        Task<BarbeiroImagens> PostBarbeiroImagemAsync(BarbeiroImagens imagem);
    }
}
