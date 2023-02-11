using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.BarbeiroImagem;
using Mybarber.DataTransferObject.Images;
using Mybarber.Presenters;
using Mybarber.Services;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/barbeiroimagem")]

    public class BarbeiroImagemControllers : ControllerBase
    {

        private readonly IBarbeiroImagemPresenter _presenter;
        private readonly IBarbeiroImagemServices _service;
        private readonly IMemoryCache _memoryCache;

        public BarbeiroImagemControllers(IBarbeiroImagemPresenter presenter, IBarbeiroImagemServices service, IMemoryCache memoryCache)
        {
            this._presenter = presenter;
            this._service = service;
            this._memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> PostBarbeiroImagemAsync(BarbeiroImagemRequestDto imagemDto)
        {
            try
            {
                var result = await _presenter.PostBarbeiroImagemAsync(imagemDto);

                return Created($"/api/v1/barbeiroImagem/{result}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }


        [HttpPost("s3")]
      
        public async Task<IActionResult> PostBarbeiroImagemS3Async([FromForm] BarbeiroImagemRequestS3Dto dto )
        {
            try
            {
                
                var result = await _service.PostBarbeiroImagemS3Async(dto);

                if (result)
                {
                    if (_memoryCache.TryGetValue(dto.Route, out var barbeariaCache))
                    {
                        _memoryCache.Remove(dto.Route);
                    }
                }

                return Created($"/api/v1/barbeiroImagem/{result}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPut("s3/{idBarbeiro}")]

        public async Task<IActionResult> PutBarbeiroImagemS3Async([FromForm] BarbeiroImagemRequestS3Dto dto)
        {
            try
            {
                var result = await _service.PutBarbeiroImagemS3Async(dto);
                if (result)
                {
                    if (_memoryCache.TryGetValue(dto.Route, out var barbeariaCache))
                    {
                        _memoryCache.Remove(dto.Route);
                    }
                }

                return Ok(result);


            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("s3/{idBarbeiro}")]
        public async Task<IActionResult> DeleteBarbeiroImagemS3Async(string route, Guid idBarbeiro)
        {
            try
            {
                var result = await _service.DeleteBarbeiroImagemS3Async(route, idBarbeiro);

                if (result)
                {
                    if (_memoryCache.TryGetValue(route, out var barbeariaCache))
                    {
                        _memoryCache.Remove(route);
                    }
                }
                return Ok(result);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
