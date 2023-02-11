using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="presenter"></param>
        public ServicoImagemControllers(IServicoImagemPresenter presenter, IServicoImagemServices servico, IMemoryCache memoryCache)
        {
            this._presenter = presenter;
            this._memoryCache = memoryCache;
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

                if (result != null)
                {
                    if (_memoryCache.TryGetValue(dto.Route, out var barbeariaCache))
                    {
                        _memoryCache.Remove(dto.Route);
                    }
                }

                return Created($"/api/v1/servicoImagem/{result}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPut("s3/{idServico}")]
        public async Task<IActionResult> UpdateServicoImagemS3Async([FromForm] ServicoImagemRequestS3Dto dto)
        {
            try
            {

                var result = await _servico.PutServicoImagemS3Async(dto);
                if (result)
                {
                    if (_memoryCache.TryGetValue(dto.Route, out var barbeariaCache))
                    {
                        _memoryCache.Remove(dto.Route);
                    }
                }

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
                if (result)
                {
                    if (_memoryCache.TryGetValue(route, out var barbeariaCache))
                    {
                        _memoryCache.Remove(route);
                    }
                }

                return Created($"/api/v1/servicoImagem/{result}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
