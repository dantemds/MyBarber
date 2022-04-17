using Mybarber.Exceptions;
using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IGenerallyRepository _generally;

        public UsersServices (IGenerallyRepository generally)
        {
          
            this._generally = generally;
            
        }

        public async Task<Users> PostUserAsync(Users users)
        {
           _generally.Add(users);

            if(await _generally.SaveChangesAsync())
            {

                return users;
            }
            else
            {
                throw new ViewException("Operação falhou");
            }
        }
    }
}
