using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class ServicosBarbeirosRepository : IServicosBarbeirosRepository
    {
        private readonly Context _context;

        public ServicosBarbeirosRepository(Context context)
        {
            _context = context;
        }

        public async Task<ServicosBarbeiros> GetServicosBarbeirosAsyncByTenant(int idTenant)
        {
            IQueryable<ServicosBarbeiros> query = _context.ServicosBarbeiros.Include(p => p.Barbeiros).Include(p => p.Servicos);

            query = query.AsNoTracking()
                .OrderBy(relacionamento => relacionamento.BarbeariasId)
                .Where(candidates => candidates.BarbeariasId == idTenant);

            return await query.FirstOrDefaultAsync();
        }





    }
}
