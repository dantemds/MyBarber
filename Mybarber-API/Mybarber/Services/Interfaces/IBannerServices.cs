using Mybarber.DataTransferObject.Banner;
using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IBannerServices
    {
        Task<Banner> PostBannerS3Async(BannerRequestDto banner);
        Task<bool> DeleteBannerImagemS3Async(string route, Guid idBanner, Guid barbeariaId, bool responsividade);
    }
}
