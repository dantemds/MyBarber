using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Barbearia;
using Mybarber.Presenter;
using System;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [EnableCors]
    [ApiController]
    [Route("api/v1/barbearias")]
    public class BarbeariasControllers : ControllerBase
    {
        private readonly IBarbeariasPresenter _presenter;
        private readonly IMemoryCache _memoryCache;
        
        public BarbeariasControllers(IBarbeariasPresenter presenter, IMemoryCache memoryCache)
        {
            this._presenter = presenter;
            this._memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBarbeariasAsync()
        {

            try
            {
                var result = await _presenter.GetAllBarbeariasAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }



        /// <summary>
        /// Método responsável por obter as barbearias utilizando o parametro IdBarbearia
        /// </summary>
        /// <param name="idBarbearia"></param>
        /// <returns></returns>
        [HttpGet("id/{idBarbearia}")]

        public async Task<IActionResult> GetBarbeariaAsyncById(Guid idBarbearia)
        {
            var result = await _presenter.GetAllAtributesBarbeariaAsyncById(idBarbearia);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpGet("{route}")]

        public async Task<IActionResult> GetBarbeariaAsyncByRoute(string route)
        {

            var key = route;
            if (_memoryCache.TryGetValue(key, out var barbeariaCache))
                return Ok(barbeariaCache);

            var result = await _presenter.GetAllAtributesBarbeariaAsyncByRoute(route);

            var memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(172800),
                SlidingExpiration = TimeSpan.FromSeconds(172800)
            };

            _memoryCache.Set(key, result, memoryCacheEntryOptions);

            if (result != null)
            {
                return Ok(result);

            } else
            {
                return NotFound();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="barbeariaDto"></param>
        /// <returns></returns>
        [HttpPost]

        public async Task<IActionResult> PostBarbeariaAsync(BarbeariasRequestDto barbeariaDto)
        {

            var result = await _presenter.PostBarbeariaAsync(barbeariaDto);

            return Created($"/api/v1/Barbearias/{result.IdBarbearia}", result);

        }
        [HttpPut("{idBarbearia}")]

        public async Task<IActionResult> PutBarbeariaAsync(Guid idBarbearia, [FromBody] BarbeariasRequestDto dto)
        {

            var result = await _presenter.PutBarbeariaAsyncById(idBarbearia, dto);




            return Ok();

        }

        [HttpPost("complete")]
        public async Task<IActionResult> PostBarbeariaCompletaAsync(BarbeariasCompleteRequestDto dto)
        {
            var result = await _presenter.PostBarbeariaCompletaAsync(dto);

            return Created("apia/v1/barbearias", result);
        }


        [HttpDelete("{idBarbearia}")]
        public async Task<IActionResult> DeleteBarbeariaAsyncById(Guid idBarbearia)
        {


            var result = await _presenter.DeleteBarbeariaAsyncById(idBarbearia);

            return Ok(result);



        }

        [HttpPatch("toggleagendamento/{idBarbearia}")]
        public async Task<IActionResult> PatchToggleAgendamentoByBarbearia(Guid idBarbearia)
        {
            var result = await _presenter.PatchToggleAgendamentoByBarbearia(idBarbearia);
            if (result != null)
            {
                if (_memoryCache.TryGetValue(result.Route, out var barbeariaCache))
                {
                    _memoryCache.Remove(result.Route);
                }
            }

            return Ok(result);
        }

        [HttpPatch("toggleativabarbearia/{idBarbearia}")]
        public async Task<IActionResult> PatchToggleAtivoByBarbearia(Guid idBarbearia)
        {
            var result = await _presenter.PatchToggleAtivoByBarbearia(idBarbearia);
            if (result != null)
            {
                if (_memoryCache.TryGetValue(result.Route, out var barbeariaCache))
                {
                    _memoryCache.Remove(result.Route);
                }
            }

            return Ok(result);
        }
    }
}
