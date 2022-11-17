
using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repositories.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class LandingPageRepository:ILandingPageRepository
    {
        private readonly Context _context;
        public LandingPageRepository(Context context)
        {
            _context = context;
        }
        public async Task<LandingPageImages> GetImagemLadingById(Guid idLading)
        {
            IQueryable<LandingPageImages> query = _context.LandingPageImages;

            query = query.AsNoTracking()
                        .OrderBy(it => it.IdLandingPageImage)
                        .Where(it => it.IdLandingPageImage == idLading);

            return query.SingleOrDefault();
        }
    }
}
