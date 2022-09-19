using Mybarber.DataTransferObject.Agendamento;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenter
{
    public interface IAgendamentosPresenter
    {
        Task<IEnumerable<AgendamentosResponseDto>> GetAllAgendamentosAsync();

        Task<AgendamentosResponseDto> GetAgendamentoAsyncById(Guid idAgendamento);

        Task<AgendamentosCompleteResponseDto> PostAgendamentoAsync(AgendamentosRequestDto agendamentoDto);

        Task<bool> DeleteAgendamentoAsyncById(Guid idAgendamento);
      
    }
}
