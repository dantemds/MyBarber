using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repositories.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class BarbeiroImagemRepository : IBarbeiroImagemRepository
    {

        private readonly Context _context;
        public BarbeiroImagemRepository(Context context)
        {
            _context = context;
        }

        public async Task<BarbeiroImagens> GetImagemBarbeiroByIdBarbeiro(Guid idBarbeiro)
        {
            IQueryable<BarbeiroImagens> query = _context.BarbeiroImagens;

            query = query.AsNoTracking()
                        .OrderBy(it => it.IdBarbeiroImagem)
                        .Where(it => it.IdBarbeiroImagem == idBarbeiro);
            
            return query.SingleOrDefault();
        }

    }
}
