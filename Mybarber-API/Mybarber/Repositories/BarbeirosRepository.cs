using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class BarbeirosRepository : IBarbeirosRepository
    {

        private readonly Context _context;

        public BarbeirosRepository(Context context)
        {
            _context = context;
        }

        //-----------------------------------------------------------------------------------------------------//

        //public async Task<Barbeiros[]> GetAllBarbeirosAsync()
        //{
        //    IQueryable<Barbeiros> query = _context.Barbeiros;

        //    query = query.AsNoTracking()
        //                 .OrderBy(barbeiros => barbeiros.IdBarbeiro);

        //    return await query.ToArrayAsync();
        //}

        public async Task<Barbeiros> GetBarbeirosAsyncById(int idBarbeiro)
        {
            IQueryable<Barbeiros> query = _context.Barbeiros.Include(p => p.ServicosBarbeiros).Include(it=> it.Barbearias);

            query = query.AsNoTracking()
                .OrderBy(barbeiros => barbeiros.IdBarbeiro)
                .Where(candidates => candidates.IdBarbeiro == idBarbeiro);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Barbeiros[]> GetBarbeirosAsyncByTenant(int idBarbearia)
        {
            IQueryable<Barbeiros> query = _context.Barbeiros;

            query = query.AsNoTracking()
                .OrderBy(barbeiros => barbeiros.IdBarbeiro)
                .Where(candidates => candidates.BarbeariasId == idBarbearia);

            return await query.ToArrayAsync();
        }
        public async Task<Barbeiros> GetBarbeirosAsyncByEmail(string email)
        {
            IQueryable<Barbeiros> query = _context.Barbeiros;

            query = query.AsNoTracking()
                .OrderBy(barbeiros => barbeiros.IdBarbeiro)
                .Where(candidates => candidates.Email == email);

            return await query.FirstOrDefaultAsync();
        }
    }
}
