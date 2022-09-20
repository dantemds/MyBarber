using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Horario;
using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
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
        private readonly IBarbeariasRepository _repo;
        private readonly IHorarioFuncionamentoServices _service;

        public HorarioFuncionamentoControllers(IGenerallyRepository generally, IMapper mapper, IBarbeariasRepository repo, IHorarioFuncionamentoServices service)
        {
            this._generally = generally;
            this._mapper = mapper;
            this._repo = repo;
            this._service = service;

        }

        [HttpPost()]
        public async Task<IActionResult> PostHorarioAsync([FromBody] HorarioFuncionamentoRequestDto horario)
        {

            var result = await _service.PostHorarioAsync(_mapper.Map<HorarioFuncionamento>(horario));

            

            if (result != null)
            {
                return Ok(horario);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut("{idBarbearia}")]

        public async Task<IActionResult> PutHorarioAsync(Guid idBarbearia, [FromBody] HorarioFuncionamentoRequestDto dto)
        {

            var horario = _mapper.Map<HorarioFuncionamento>(dto);

            var barbeariaFinded = await _repo.GetBarbeariasAsyncById(idBarbearia);

            horario.IdHorarioFuncionamento = barbeariaFinded.HorarioFuncionamento.IdHorarioFuncionamento;
            horario.BarbeariasId = barbeariaFinded.HorarioFuncionamento.BarbeariasId;

            _generally.Update(horario);

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
