using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly Context _context;

        public UsersRepository(Context context)
        {
            _context = context;
        }

        //-----------------------------------------------------------------------------------------------------//

        public async Task<Users> GetUserAsync(string email, string password)
        {
            try
            {
                IQueryable<Users> query = _context.Users;
                query = query.AsNoTracking()
                       .OrderBy(users => users.IdUser)
                       .Where(users => users.Email == email && users.Password == password);

                return await query.FirstOrDefaultAsync();
            }catch(Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Users> GetUserAsyncByEmail(string email)
        {
            try
            {
                IQueryable<Users> query = _context.Users;

                query = query.AsNoTracking()
                       .OrderBy(users => users.IdUser)
                       .Where(users => users.Email == email);

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        public async Task<Users> GetUserAsyncById(int id)
        {
            try
            {
                IQueryable<Users> query = _context.Users;

                query = query.AsNoTracking()
                       .OrderBy(users => users.IdUser)
                       .Where(users => users.IdUser == id);

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }


    }
}
