using Mybarber.DataTransferObject.Agenda;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenters.Interfaces
{
    public interface IAgendasPresenter
    {
        Task<AgendasRequestDto> PostAgendaAsync(AgendasRequestDto agendasDto);
        Task<List<float>> GerarHorariosAgedamentos(int idBarbeiro, DateTime data, string dia, int idServico, int tenant);
    }
}
