using Mybarber.DataTransferObject.Barbearia;
using Mybarber.DataTransferObject.Images;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public interface IServicoImagemPresenter
    {
        Task<ServicoImagemRequestDto> PostServicoImagemAsync(ServicoImagemRequestDto imagemDto);
    }
}
