using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repositories.Interface
{
    public interface IRolesRepository
    {
        Task<Role[]> GetAllRolesAsync();
    }
}
