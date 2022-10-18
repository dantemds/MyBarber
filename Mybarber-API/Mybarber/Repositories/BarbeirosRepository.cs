using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repository;
using System;
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

        public async Task<Barbeiros> GetBarbeirosAsyncById(Guid idBarbeiro)
        {
            IQueryable<Barbeiros> query = _context.Barbeiros.Include(p => p.ServicosBarbeiros).Include(it=> it.Barbearias).Include(p=>p.Agendas);

            query = query.AsNoTracking()
                .OrderBy(barbeiros => barbeiros.IdBarbeiro)
                .Where(candidates => candidates.IdBarbeiro == idBarbeiro);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Barbeiros[]> GetBarbeirosAsyncByTenant(Guid idBarbearia)
        {
            IQueryable<Barbeiros> query = _context.Barbeiros;

            query = query.AsNoTracking()
                .OrderBy(barbeiros => barbeiros.IdBarbeiro)
                .Where(candidates => candidates.BarbeariasId == idBarbearia);

            return await query.ToArrayAsync();
        }
        public async Task<Barbeiros> GetBarbeirosAsyncByUserId(Guid userId)
        {
            IQueryable<Barbeiros> query = _context.Barbeiros;

            query = query.AsNoTracking()
                .OrderBy(barbeiros => barbeiros.IdBarbeiro)
                .Where(candidates => candidates.UsersId == userId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
