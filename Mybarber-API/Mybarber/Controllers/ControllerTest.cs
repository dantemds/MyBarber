using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.Services;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/agendaTest")]

    public class ControllerTest:ControllerBase
    {
        private readonly IAgendasServices agenda;

        public ControllerTest(IAgendasServices agenda)
        {
           
            this.agenda = agenda;
        }

        [HttpGet]
        [Route("/teste")]
        public async Task<IActionResult> testeData(int idServico, int idBarbeiro)
        {
            var result = agenda.PopularHorario(idServico, idBarbeiro);
            return Ok(result);
        }
        
    }
}
