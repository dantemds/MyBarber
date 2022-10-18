using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IRolesUsersServices
    {
        Task<RolesUsers> PostRelacionamentoAsync(RolesUsers rolesUsers);
    }
}
