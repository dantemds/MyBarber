using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.LadingPageImages;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/agendamentos")]
    public class LandingPageImagesControllers:ControllerBase
    {
        private readonly ILandingPageServices _service;
        public LandingPageImagesControllers(ILandingPageServices service)
        {
            this._service = service;
        }
        public async Task<IActionResult> PostLadingPageImageS3Async(LandingPageImagesRequestDto dto)
        {
            try
            {

                var result = await _service.PostLadingPageImageS3Async(dto);

                return Created($"/api/v1/ladingpageimage/{result}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
