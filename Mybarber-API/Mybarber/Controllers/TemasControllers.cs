using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.Models;
using Mybarber.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/temas")]
    public class TemasControllers : ControllerBase
    {
        private readonly IGenerallyRepository _generally;
        public TemasControllers( IGenerallyRepository generally)
        {
            this._generally = generally;
        }

        [HttpPost()]
        public async Task<IActionResult> PostTemaAsync([FromBody] Temas tema)
        {
            _generally.Add(tema);

            if(await _generally.SaveChangesAsync())
            {
                return Ok(tema);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
