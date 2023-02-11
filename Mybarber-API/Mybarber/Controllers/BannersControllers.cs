using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Banner;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/banners")]
    public class BannersControllers :ControllerBase
    {
        private readonly IBannerServices _servico;
        private readonly IMemoryCache _memoryCache;
        public BannersControllers(IBannerServices servico, IMemoryCache memoryCache)
        {
            this._servico = servico;
            this._memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> PostBannerS3Async([FromForm] BannerRequestDto bannerDto)
        {
            try
            {

                var result = await _servico.PostBannerS3Async(bannerDto);
                if (result != null)
                {
                    if (_memoryCache.TryGetValue(bannerDto.Route, out var barbeariaCache))
                    {
                        _memoryCache.Remove(bannerDto.Route);
                    }
                }

                return Created($"/api/v1/banner/{result}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpDelete("s3/{idBanner}")]
        public async Task<IActionResult> DeleteBannerImagemS3Async(string route, Guid idBanner, Guid barbeariaId, bool responsividade)
        {
            try
            {
                var result = await _servico.DeleteBannerImagemS3Async(route, idBanner, barbeariaId, responsividade);

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
