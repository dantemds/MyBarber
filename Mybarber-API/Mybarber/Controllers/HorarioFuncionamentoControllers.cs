using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Horario;
using Mybarber.Models;
using Mybarber.Repository;
using System.Threading.Tasks;

namespace Mybarber.Controllers

{

    [EnableCors]
    [ApiController]
    [Route("api/v1/horario")]
    public class HorarioFuncionamentoControllers : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenerallyRepository _generally;
        public HorarioFuncionamentoControllers(IGenerallyRepository generally, IMapper mapper)
        {
            this._generally = generally;
            this._mapper = mapper;

        }

        [HttpPost()]
        public async Task<IActionResult> PostHorarioAsync([FromBody] HorarioFuncionamentoRequestDto horario)
        {



            _generally.Add(_mapper.Map<HorarioFuncionamento>(horario));

            if (await _generally.SaveChangesAsync())
            {
                return Ok(horario);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
