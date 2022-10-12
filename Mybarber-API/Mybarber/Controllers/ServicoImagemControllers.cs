using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Images;
using Mybarber.DataTransferObject.ServicoImagem;
using Mybarber.Presenters;
using Mybarber.Services;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{/// <summary>
/// 
/// </summary>
    [EnableCors]
    [ApiController]
    [Route("api/v1/servicoimagem")]
    public class ServicoImagemControllers : ControllerBase
    {
        private readonly IServicoImagemPresenter _presenter;
        private readonly IServicoImagemServices _servico;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="presenter"></param>
        public ServicoImagemControllers(IServicoImagemPresenter presenter, IServicoImagemServices servico)
        {
            this._presenter = presenter;
            this._servico = servico;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imagemDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostServicoImagemAsync(ServicoImagemRequestDto imagemDto)
        {
            try
            {

                var result = await _presenter.PostServicoImagemAsync(imagemDto);




                return Created($"/api/v1/servicoImagem/", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPost("s3")]
        public async Task<IActionResult> PostServicoImagemS3Async([FromForm] ServicoImagemRequestS3Dto dto)
        {
            try
            {

                var result = await _servico.PostServicoImagemS3Async(dto);

                return Created($"/api/v1/servicoImagem/{result}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPut("s3/{idServico}")]
        public async Task<IActionResult> UpdateServicoImagemS3Async([FromForm(Name = "image")] IFormFile file, [FromForm(Name = "route")] string route, [FromForm(Name = "servico")] Guid idServico, [FromForm(Name = "nome")] string nomeImagem)
        {
            try
            {

                var result = await _servico.PutServicoImagemS3Async(file, route, idServico, nomeImagem);

                return Created($"/api/v1/servicoImagem/{result}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpDelete("s3/{idServico}")]
        public async Task<IActionResult> DeleteServicoImagemS3Async(string route, Guid idServico)
        {
            try
            {

                var result = await _servico.DeleteServicoImagemS3Async(route, idServico);

                return Created($"/api/v1/servicoImagem/{result}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
