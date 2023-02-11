using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.LadingPageImages;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/landingpage")]
    public class LandingPageImagesControllers:ControllerBase
    {
        private readonly ILandingPageServices _service;
        private readonly IMemoryCache _memoryCache;
        public LandingPageImagesControllers(ILandingPageServices service, IMemoryCache memoryCache)
        {
            this._service = service;
            this._memoryCache = memoryCache;
        }
        [HttpPost]
        public async Task<IActionResult> PostLadingPageImageS3Async([FromForm] LandingPageImagesRequestDto dto)
        {
            try
            {
                
                var result = await _service.PostLadingPageImageS3Async(dto);

                if (result != null)
                {
                    if (_memoryCache.TryGetValue(dto.Route, out var barbeariaCache))
                    {
                        _memoryCache.Remove(dto.Route);
                    }
                }

                return Created($"/api/v1/ladingpageimage/{result}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPut("s3/{idLading}")]

        public async Task<IActionResult> PutBarbeiroImagemS3Async([FromForm] LandingPageImagesRequestDto dto, Guid idLandingPage)
        {
            try
            {
                var result = await _service.PutLadingImagemS3Async(dto, idLandingPage);

                if (result)
                {
                    if (_memoryCache.TryGetValue(dto.Route, out var barbeariaCache))
                    {
                        _memoryCache.Remove(dto.Route);
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
