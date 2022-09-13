using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Temas;
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
        private readonly IMapper _mapper;
        private readonly IGenerallyRepository _generally;
        private readonly IBarbeariasRepository _repo;

        public TemasControllers( IGenerallyRepository generally, IMapper mapper, IBarbeariasRepository repo)
        {
            this._generally = generally;
            this._mapper = mapper;
            this._repo = repo;

        }

        [HttpPost()]
        public async Task<IActionResult> PostTemaAsync([FromBody] TemasRequestDto tema)
        {



            _generally.Add(_mapper.Map<Temas>(tema));

            if(await _generally.SaveChangesAsync())
            {
                return Ok(tema);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{idBarbearia}")]

        public async Task<IActionResult> PutTemaAsync(Guid idBarbearia, [FromBody] TemasRequestDto temaDto)
        {
            var tema = _mapper.Map<Temas>(temaDto);

            var barbeariaFinded = await _repo.GetBarbeariasAsyncById(idBarbearia);



            tema.BarbeariasId = barbeariaFinded.Temas.BarbeariasId;
            tema.IdTema = barbeariaFinded.Temas.IdTema;
            _generally.Update(tema);

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
