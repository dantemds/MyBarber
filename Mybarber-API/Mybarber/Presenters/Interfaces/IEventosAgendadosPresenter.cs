﻿using Mybarber.DataTransferObject.EventoAgendado;
using System.Threading.Tasks;

namespace Mybarber.Presenters.Interfaces
{
    public interface IEventosAgendadosPresenter
    {
        Task<EventoAgendadoRequestDto> PostEventoAgendadoAsync(EventoAgendadoRequestDto dto);
        Task<bool> DeleteEventoAgendadoAsync(int idEvento);
        Task<EventoAgendadoResponseDto> UpdateEventoAgendadoAsync(EventoAgendadoRequestDto dto, int idEvento);
    }
}
