using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Enderecos;
using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
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
        private readonly IEnderecosServices _service;
        public EnderecosControllers(IGenerallyRepository generally, IMapper mapper, IEnderecosServices service)
        {
            this._generally = generally;
            this._mapper = mapper;
            this._service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> PostEnderecoAsync([FromBody] EnderecosRequestDto endereco)
        {



            var result = await _service.PostEnderecoAsync(_mapper.Map<Enderecos>(endereco));

            if (result != null)
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
