using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Images;
using Mybarber.Presenters;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="presenter"></param>
        public ServicoImagemControllers(IServicoImagemPresenter presenter)
        {
            this._presenter = presenter;
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
    }
}
