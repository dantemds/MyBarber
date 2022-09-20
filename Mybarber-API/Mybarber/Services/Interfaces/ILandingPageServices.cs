using Mybarber.DataTransferObject.LadingPageImages;
using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface ILandingPageServices
    {
        Task<LandingPageImages> PostLadingPageImageS3Async(LandingPageImagesRequestDto dto);
    }
}
