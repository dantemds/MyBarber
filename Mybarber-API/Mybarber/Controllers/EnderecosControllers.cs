using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Enderecos;
using Mybarber.Models;
using Mybarber.Repository;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/enderecos")]
    public class EnderecosControllers : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenerallyRepository _generally;
        public EnderecosControllers(IGenerallyRepository generally, IMapper mapper)
        {
            this._generally = generally;
            this._mapper = mapper;
        }

        [HttpPost()]
        public async Task<IActionResult> PostEnderecoAsync([FromBody] EnderecosRequestDto endereco)
        {



            _generally.Add(_mapper.Map<Enderecos>(endereco));

            if (await _generally.SaveChangesAsync())
            {
                return Ok(endereco);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
