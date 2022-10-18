using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repositories.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class RolesRepository: IRolesRepository
    {
        private readonly Context _context;
        public RolesRepository(Context context)
        {
            _context = context;
        }
        public async Task<Role[]> GetAllRolesAsync()
        {
            try
            {
                IQueryable<Role> query = _context.Role;
                    

                query = query.AsNoTracking()
                             .OrderBy(it => it.IdRole);

                return await query.ToArrayAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

    }
}
