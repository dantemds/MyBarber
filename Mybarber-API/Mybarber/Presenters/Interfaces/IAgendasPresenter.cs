using Mybarber.DataTransferObject.Agenda;

using System.Threading.Tasks;

namespace Mybarber.Presenters.Interfaces
{
    public interface IAgendasPresenter
    {
        Task<AgendasRequestDto> PostAgendaAsync(AgendasRequestDto agendasDto);
    }
}
