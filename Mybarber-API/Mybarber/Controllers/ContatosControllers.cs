using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Contatos;
using Mybarber.Models;
using Mybarber.Repository;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/contatos")]
    public class ContatosControllers : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IGenerallyRepository _generally;
        public ContatosControllers(IGenerallyRepository generally, IMapper mapper)
        {
            this._generally = generally;
            this._mapper = mapper;
        }

        [HttpPost()]
        public async Task<IActionResult> PostContatosAsync([FromBody] ContatosRequestDto contato)
        {



            _generally.Add(_mapper.Map<Contatos>(contato));

            if (await _generally.SaveChangesAsync())
            {
                return Ok(contato);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
