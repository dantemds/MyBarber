
using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repositories.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class BannerRepository:IBannerRepository
    {
        private readonly Context _context;
        public BannerRepository(Context context)
        {
            _context = context;
        }

        public async Task<Banner> GetImagemBannerById(Guid idBanner)
        {
            IQueryable<Banner> query = _context.Banner;

            query = query.AsNoTracking()
                        .OrderBy(it => it.IdBanner)
                        .Where(it => it.IdBanner == idBanner);

            return query.SingleOrDefault();
        }
    }
}
