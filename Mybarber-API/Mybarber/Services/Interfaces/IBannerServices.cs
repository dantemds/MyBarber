using Mybarber.DataTransferObject.Banner;
using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IBannerServices
    {
        Task<Banner> PostBannerS3Async(BannerRequestDto banner);
    }
}
