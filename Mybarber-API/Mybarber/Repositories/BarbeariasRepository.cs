using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repository;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace Mybarber.Repositories
{
    public class BarbeariasRepository : IBarbeariasRepository

    {
        private readonly Context _context;

        public BarbeariasRepository(Context context)
        {
            _context = context;
        }

        //-----------------------------------------------------------------------------------------------------//

        public async Task<Barbearias[]> GetAllBarbeariasAsync()
        {
            try
            {
                IQueryable<Barbearias> query = _context.Barbearias.Include(p => p.Barbeiros)
                    .Include(p => p.Servicos)
                    .Include(p => p.ServicosBarbeiros);

                query = query.AsNoTracking()
                             .OrderBy(barbearias => barbearias.IdBarbearia);

                return await query.ToArrayAsync();
            }
            catch (Exception) 
            {
                throw new Exception();
            }
            
        }

        public async Task<Barbearias> GetBarbeariasAsyncById(int idBarbearia)
        {
            try
            {

                IQueryable<Barbearias> query = _context.Barbearias.Include(p => p.Barbeiros).ThenInclude(it => it.BarbeiroImagem).Include(it => it.Barbeiros).ThenInclude(it=>it.Agendas)
                    .Include(p => p.Servicos).ThenInclude(it => it.ServicoImagem)
                    .Include(it => it.Servicos).ThenInclude(it => it.ServicosBarbeiros).ThenInclude(it => it.Barbeiros).ThenInclude(it => it.BarbeiroImagem)
                    .Include(it => it.Servicos).ThenInclude(it => it.ServicosBarbeiros).ThenInclude(it => it.Barbeiros).ThenInclude(it => it.Agendas)
                .Include(it => it.Agendamentos).ThenInclude(it => it.Servicos)
                .Include(it => it.Agendamentos).ThenInclude(it => it.Barbeiros);


                query = query.AsNoTracking()
                    
                    .OrderBy(barbearias => barbearias.IdBarbearia)
                    .Where(barbearias => barbearias.IdBarbearia == idBarbearia);

                return await query.FirstOrDefaultAsync();
            }catch(Exception)
            {
                throw new Exception();

            }
        }
    }
}
