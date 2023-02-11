using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class ServicosRepository : IServicosRepository
    {

            private readonly Context _context;

            public ServicosRepository(Context context)
            {
                _context = context;
            }

            //-----------------------------------------------------------------------------------------------------//

        //    public async Task<Servicos[]> GetAllServicosAsync()
        //{
        //    IQueryable<Servicos> query = _context.Servicos;

        //    query = query.AsNoTracking()
        //                 .OrderBy(servicos => servicos.IdServico);

        //    return await query.ToArrayAsync();
        //}

        public async Task<Servicos> GetServicosAsyncById(Guid idServico)
        {
            IQueryable<Servicos> query = _context.Servicos.Include(p => p.ServicosBarbeiros).Include(p => p.ServicoImagem).Include(p=>p.Barbearias);

            query = query.AsNoTracking()
                .OrderBy(servicos => servicos.IdServico)
                .Where(servicos => servicos.IdServico == idServico);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Servicos[]> GetServicosAsyncByTenant(Guid idBarbearia)
        {
            IQueryable<Servicos> query = _context.Servicos;

            query = query.AsNoTracking()
                .OrderBy(servicos => servicos.IdServico)
                .Where(servicos => servicos.BarbeariasId == idBarbearia);

            return await query.ToArrayAsync();
        }
    }
}
