using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Contatos;
using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/contatos")]
    public class ContatosControllers : ControllerBase
    {
        private readonly IBarbeariasRepository _repo;
        private readonly IMapper _mapper;
        private readonly IGenerallyRepository _generally;
        private readonly IContatosServices _service;
        public ContatosControllers(IGenerallyRepository generally, IMapper mapper, IBarbeariasRepository repo, IContatosServices service)
        {
            this._generally = generally;
            this._repo = repo;
            this._mapper = mapper;
            this._service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> PostContatosAsync([FromBody] ContatosRequestDto contato)
        {



            var result = await _service.PostContatosAsync(_mapper.Map<Contatos>(contato));

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{idBarbearia}")]

        public async Task<IActionResult> PutBarbeariaAsync(Guid idBarbearia, [FromBody] ContatosRequestDto dto)
        {
            var contato = _mapper.Map<Contatos>(dto);
            var barbeariaFinded = await _repo.GetBarbeariasAsyncById(idBarbearia);

            contato.BarbeariasId = barbeariaFinded.Contatos.BarbeariasId;
            contato.IdContato = barbeariaFinded.Contatos.IdContato;

            _generally.Update(contato);

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
