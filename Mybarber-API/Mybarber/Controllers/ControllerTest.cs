using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.Services;
using System;
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
        [Route("/teste/{tenant:int}")]
        public async Task<IActionResult> testeData( int idBarbeiro, DateTime data,string dia,int idServico,int tenant )
        {
            var result =await agenda.PopularHorario(idBarbeiro,dia,data, tenant, idServico);
           
            return Ok(result);
        }
        
    }
}
