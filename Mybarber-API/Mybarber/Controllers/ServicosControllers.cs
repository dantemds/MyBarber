using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Servico;
using Mybarber.Presenter;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors]
    [ApiController]
    [Route("api/v1/servicos")]

    public class ServicosControllers : ControllerBase
    {

        private readonly IServicosPresenter _presenter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="presenter"></param>
        public ServicosControllers(IServicosPresenter presenter)
        {
            this._presenter = presenter;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllServicosAsync()
        //{

        //    try
        //    {
        //        var result = await _presenter.GetAllServicosAsync();

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Erro:{ex.Message}");
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idServico"></param>
        /// <returns></returns>

        [HttpGet("{idServico}")]
        public async Task<IActionResult> GetServicoAsyncById(Guid idServico)
        {
            try
            {
                var result = await _presenter.GetServicoAsyncById(idServico);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex.Message}");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idBarbearia"></param>
        /// <returns></returns>
        [HttpGet("barbearia/{idBarbearia}")]
        public async Task<IActionResult> GetBarbeariaAsyncByTenant(Guid idBarbearia)
        {
            try
            {
                var result = await _presenter.GetServicoAsyncByTenant(idBarbearia);


                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex.Message}");
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="servicoDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostServicoAsync(ServicosRequestDto servicoDto)
        {
            try
            {
                var result = await _presenter.PostServicoAsync(servicoDto);

                return Created($"/api/v1/candidates/{result.IdServico}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
        [HttpPost("servicoCompleto")]
        public async Task<IActionResult> PostServicoCompletoAsync(ServicosCompleteRequestDto servicoDto)
        {
            try
            {

                var result = await _presenter.PostServiceCompleteAsync(servicoDto);

                return Created($"/api/v1/servico/", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }


        [HttpDelete("{idServico}")]
        public async Task<IActionResult> DeleteServicoAsyncById(Guid idServico)
        {

            try
            {
                var result = await _presenter.DeleteServicoAsyncById(idServico);

            return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}