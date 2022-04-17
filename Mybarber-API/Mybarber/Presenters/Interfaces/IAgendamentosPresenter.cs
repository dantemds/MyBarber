using Mybarber.DataTransferObject.Agendamento;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenter
{
    public interface IAgendamentosPresenter
    {
        Task<IEnumerable<AgendamentosResponseDto>> GetAllAgendamentosAsync();

        Task<AgendamentosResponseDto> GetAgendamentoAsyncById(int idAgendamento);

        Task<AgendamentosCompleteResponseDto> PostAgendamentoAsync(AgendamentosRequestDto agendamentoDto);

        Task<bool> DeleteAgendamentoAsyncById(int idAgendamento);
      
    }
}
