using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Images;
using Mybarber.Presenters;
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


        public BarbeiroImagemControllers(IBarbeiroImagemPresenter presenter)
        {
            this._presenter = presenter;

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

    }
}
