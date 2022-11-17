using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Repositories.Interface
{
    public interface IBannerRepository
    {
        Task<Banner> GetImagemBannerById(Guid idBanner);
    }
}
