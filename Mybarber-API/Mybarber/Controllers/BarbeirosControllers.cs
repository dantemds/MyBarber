using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.Presenter;
using System;
using System.Threading.Tasks;


namespace Mybarber.Controllers
{/// <summary>
/// 
/// </summary>
    [EnableCors]
    [ApiController]
    [Route("api/v1/barbeiros")]
    public class BarbeirosControllers : ControllerBase
    {
        private readonly IBarbeirosPresenter _presenter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="presenter"></param>
        public BarbeirosControllers(IBarbeirosPresenter presenter)
        {
            this._presenter = presenter;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllBarbeirosAsync()
        //{

        //    try
        //    {
        //        var result = await _presenter.GetAllBarbeirosAsync();

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
        /// <param name="idBarbeiro"></param>
        /// <returns></returns>
        [HttpGet("{idBarbeiro:int}")]
        public async Task<IActionResult> GetBarbeiroAsyncById(int idBarbeiro)
        {
            try
            {
                var result = await _presenter.GetBarbeiroAsyncById(idBarbeiro);

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
        [HttpGet("barbearia/{idBarbearia:int}")]
        public async Task<IActionResult> GetBarbeiroAsyncByTenant(int idBarbearia)
        {
            try
            {
                var result = await _presenter.GetBarbeiroAsyncByTenant(idBarbearia);

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
        /// <param name="barbeiroDto"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> PostBarbeiroAsync(BarbeirosRequestDto barbeiroDto)
        {
            
                var result = await _presenter.PostBarbeiroAsync(barbeiroDto);

                return Created($"/api/v1/barbeiros/{result.IdBarbeiro}", result);
            
           
        }
        [HttpDelete("{idBarbeiro:int}")]
        public async Task<IActionResult> DeleteBarbeiroAsyncById(int idBarbeiro)
        {

            try
            {
                var result = await _presenter.DeleteBarbeiroAsyncById(idBarbeiro);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        //[HttpPut("{idBarbeiro:int")]
        //public async Task<IActionResult> UpdateBarbeiroById(int idBarbeiro)
        //{

        //    var result = await _presenter.UpdateBarbeiroAsyncById(idBarbeiro);
        //    return Ok();
        //}

        
    }
}
