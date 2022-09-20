using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface ITemasServices
    {
        Task<Temas> PostTemaAsync(Temas tema);
    }
}
