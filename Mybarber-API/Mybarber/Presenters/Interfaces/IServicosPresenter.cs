using Mybarber.DataTransferObject.Servico;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenter
{
    public interface IServicosPresenter
    {
        //Task<IEnumerable<ServicosResponseDto>> GetAllServicosAsync();

        Task<ServicosResponseDto> GetServicoAsyncById(Guid idServico);

        Task<List<ServicosResponseDto>> GetServicoAsyncByTenant(Guid idBarbearia);

        Task<ServicosCompleteResponseDto> PostServicoAsync(ServicosRequestDto servicoDto);
       Task<ServicosCompleteResponseDto> PostServiceCompleteAsync(ServicosCompleteRequestDto servicoDto);
        Task<ServicosCompleteResponseDto> DeleteServicoAsyncById(Guid idServico);
    }
}
