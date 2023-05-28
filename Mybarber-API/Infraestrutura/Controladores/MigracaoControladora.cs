using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Infraestrutura.Controladores
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/migracao")]
    public class MigracaoControladora : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> TestandoMigracao()
        {
            return Ok("Migração realizada com sucesso");
        }
    }
}
