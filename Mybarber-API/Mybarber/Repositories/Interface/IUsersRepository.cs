using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public interface IUsersRepository

    {
        Task<Users> GetUserAsync(string username, string password);
        Task<Users> GetUserAsyncByEmail(string email);
        Task<Users> GetUserAsyncById(Guid id);
        Task<Users[]> GetUsersByTenant(Guid tenantId);
    }

}
