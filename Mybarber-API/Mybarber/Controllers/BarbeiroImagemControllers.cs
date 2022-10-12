using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.BarbeiroImagem;
using Mybarber.DataTransferObject.Images;
using Mybarber.Presenters;
using Mybarber.Services;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/barbeiroimagem")]

    public class BarbeiroImagemControllers : ControllerBase
    {

        private readonly IBarbeiroImagemPresenter _presenter;
        private readonly IBarbeiroImagemServices _service;

        public BarbeiroImagemControllers(IBarbeiroImagemPresenter presenter, IBarbeiroImagemServices service)
        {
            this._presenter = presenter;
            this._service = service;

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

                return Created($"/api/v1/barbeiroImagem/{result}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPut("s3/{idBarbeiro}")]

        public async Task<IActionResult> PutBarbeiroImagemS3Async([FromForm(Name = "image")] IFormFile file, [FromForm(Name = "route")] string route, [FromForm(Name = "barbeiro")] Guid idBarbeiro, [FromForm(Name = "nome")] string nomeImagem)
        {
            try
            {
                var result = await _service.PutBarbeiroImagemS3Async(file, route, idBarbeiro, nomeImagem);

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

                return Ok(result);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
