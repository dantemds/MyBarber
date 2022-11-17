using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repositories.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class ServicoImagemRepository : IServicoImagemRepository
    {
        private readonly Context _context;
        public ServicoImagemRepository(Context context)
        {
            this._context = context;
        }

        public async Task<ServicoImagens> GetImagemServicoByIdServico(Guid idServico)
        {
            IQueryable<ServicoImagens> query = _context.ServicoImagens;

            query = query.AsNoTracking()
                        .OrderBy(it => it.IdImagemServico)
                        .Where(it => it.IdImagemServico == idServico);

            return query.SingleOrDefault();
        }
    }
}
