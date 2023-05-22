using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.Presenter;
using System;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;


namespace Mybarber.Controllers
{/// <summary>
/// 
/// </summary>
    [EnableCors]
    [ApiController]
    [Route("api/v1/barbeiros")]
    public class BarbeirosControllers : ControllerBase
    {
        private readonly IBarbeirosPresenter _presenter;
        private readonly IMemoryCache _memoryCache;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="presenter"></param>
        public BarbeirosControllers(IBarbeirosPresenter presenter, IMemoryCache memoryCache)
        {
            this._presenter = presenter;
            this._memoryCache = memoryCache;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllBarbeirosAsync()
        //{

        //    try
        //    {
        //        var result = await _presenter.GetAllBarbeirosAsync();

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Erro:{ex.Message}");
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idBarbeiro"></param>
        /// <returns></returns>
        [HttpGet("{idBarbeiro}")]
        public async Task<IActionResult> GetBarbeiroAsyncById(Guid idBarbeiro)
        {
            try
            {
                var result = await _presenter.GetBarbeiroAsyncById(idBarbeiro);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex.Message}");
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idBarbearia"></param>
        /// <returns></returns>
        [HttpGet("barbearia/{idBarbearia}")]
        public async Task<IActionResult> GetBarbeiroAsyncByTenant(Guid idBarbearia)
        {
            try
            {
                var result = await _presenter.GetBarbeiroAsyncByTenant(idBarbearia);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex.Message}");
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="barbeiroDto"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> PostBarbeiroAsync(BarbeirosRequestDto barbeiroDto)
        {
            
                var result = await _presenter.PostBarbeiroAsync(barbeiroDto);

            if (result != null)
            {
                if (_memoryCache.TryGetValue(result.Route, out var barbeariaCache))
                {
                    _memoryCache.Remove(result.Route);
                }
            }

            return Created($"/api/v1/barbeiros/{result.IdBarbeiro}", result);
            
           
        
        }

        [HttpPost("comservico")]
        public async Task<IActionResult> PostBarbeiroComTodosServicosAsync(BarbeirosRequestDto barbeiroDto)
        {

            var result = await _presenter.PostBarbeiroTodosServicosAsync(barbeiroDto);

            if (result != null)
            {
                if (_memoryCache.TryGetValue(result.Route, out var barbeariaCache))
                {
                    _memoryCache.Remove(result.Route);
                }
            }

            return Created($"/api/v1/barbeiros/{result.IdBarbeiro}", result);
        }

        [HttpDelete("{idBarbeiro}")]
        public async Task<IActionResult> DeleteBarbeiroAsyncById(Guid idBarbeiro)
        {

            try
            {
                var result = await _presenter.DeleteBarbeiroAsyncById(idBarbeiro);

                if (result != null)
                {
                    if (_memoryCache.TryGetValue(result.Route, out var barbeariaCache))
                    {
                        _memoryCache.Remove(result.Route);
                    }
                }

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        //[HttpPut("{idBarbeiro:int")]
        //public async Task<IActionResult> UpdateBarbeiroById(int idBarbeiro)
        //{

        //    var result = await _presenter.UpdateBarbeiroAsyncById(idBarbeiro);
        //    return Ok();
        //}

        
    }
}
