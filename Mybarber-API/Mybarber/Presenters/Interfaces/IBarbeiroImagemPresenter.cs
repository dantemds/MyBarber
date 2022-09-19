using Mybarber.DataTransferObject.Images;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public interface IBarbeiroImagemPresenter
    {
        Task<BarbeiroImagemRequestDto> PostBarbeiroImagemAsync(BarbeiroImagemRequestDto imagemDto);
        //Task<BarbeiroImagemRequestDto> PostBarbeiroImagemS3Async(BarbeiroImagemRequestDto imagemDto);
    }
}
