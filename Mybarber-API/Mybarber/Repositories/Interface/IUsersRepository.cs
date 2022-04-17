using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public interface IUsersRepository

    {
        Task<Users> GetUserAsync(string username, string password);
        Task<Users> GetUserAsyncByEmail(string email);
        Task<Users> GetUserAsyncById(int id);
    }

}
