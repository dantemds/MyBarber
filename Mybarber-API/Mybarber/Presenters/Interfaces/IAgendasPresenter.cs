using Mybarber.DataTransferObject.Agenda;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenters.Interfaces
{
    public interface IAgendasPresenter
    {
        Task<AgendasRequestDto> PostAgendaAsync(AgendasRequestDto agendasDto);
        Task<List<float>> GerarHorariosAgedamentos(Guid idBarbeiro, DateTime data, string dia, Guid idServico, Guid tenant);
    }
}
