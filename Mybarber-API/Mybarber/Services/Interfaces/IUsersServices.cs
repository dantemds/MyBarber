using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IUsersServices
    {

        Task<Users> PostUserAsync(Users users);
    }
}
