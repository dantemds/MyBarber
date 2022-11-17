using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Banner;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/banners")]
    public class BannersControllers :ControllerBase
    {
        private readonly IBannerServices _servico;
        public BannersControllers(IBannerServices servico)
        {
            this._servico = servico;
        }

        [HttpPost]
        public async Task<IActionResult> PostBannerS3Async([FromForm] BannerRequestDto bannerDto)
        {
            try
            {

                var result = await _servico.PostBannerS3Async(bannerDto);

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

                return Ok(result);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
