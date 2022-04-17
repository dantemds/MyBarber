using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Agenda;
using Mybarber.DataTransferObject.Barbearia;
using Mybarber.Presenter;
using Mybarber.Presenters.Interfaces;
using Mybarber.Repository;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{

    [EnableCors]
    [ApiController]
    [Route("api/v1/agendas")]
    public class AgendasControllers : ControllerBase
    {

        private readonly IAgendasPresenter _presenter;
        public AgendasControllers(IAgendasPresenter presenter)
        {
            this._presenter = presenter;

        }

        [HttpPost]
        public async Task<IActionResult> PostAgendaAsync(AgendasRequestDto agendasDto)
        {
            try
            {
                var result = await _presenter.PostAgendaAsync(agendasDto);

                return Created($"/api/v1/agendas/{result}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
