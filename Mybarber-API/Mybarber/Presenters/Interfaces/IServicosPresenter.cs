using Mybarber.DataTransferObject.Servico;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenter
{
    public interface IServicosPresenter
    {
        //Task<IEnumerable<ServicosResponseDto>> GetAllServicosAsync();

        Task<ServicosResponseDto> GetServicoAsyncById(int idServico);

        Task<ServicosResponseDto> GetServicoAsyncByTenant(int idBarbearia);

        Task<ServicosCompleteResponseDto> PostServicoAsync(ServicosRequestDto servicoDto);
        Task<string> DeleteServicoAsyncById(int idServico);
    }
}
