using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.EventoAgendado;
using Mybarber.Presenters.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/eventosagendados")]
    public class EventosAgendadosControllers : ControllerBase
    {
        private readonly IEventosAgendadosPresenter _presenter;

        public EventosAgendadosControllers(IEventosAgendadosPresenter presenter)
        {
            this._presenter = presenter;
        }

        [HttpPost]
        public async Task<IActionResult> PostEventoAgendadoAsync(EventoAgendadoRequestDto dto)
        {
            try
            {
                
                var result = await _presenter.PostEventoAgendadoAsync(dto);

                return Created($"/api/v1/eventosagendados/{result.BarbeirosId}", result);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }


        [HttpDelete("{idEvento}")]
        public async Task<IActionResult> DeleteEventoAgendados(int idEvento)
        {
            try
            {

                var result = await _presenter.DeleteEventoAgendadoAsync(idEvento);

                return Ok(result);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }

        [HttpPut("{idEvento}")]
        public async Task<IActionResult> UpdateEventoAgendados(EventoAgendadoRequestDto dto, int idEvento)
        {
            try
            {

                var result = await _presenter.UpdateEventoAgendadoAsync(dto,idEvento);

                return Ok(result);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }
    }
}
