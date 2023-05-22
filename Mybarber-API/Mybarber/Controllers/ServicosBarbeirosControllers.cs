using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Mybarber.DataTransferObject.Relacionamento;
using Mybarber.Persistencia;
using Mybarber.Presenter;
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
    [Route("api/v1/servicosbarbeiros")]
    public class ServicosBarbeirosControllers : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IServicosBarbeirosPresenter _presenter;
        private readonly IBarbeirosServices _barbeirosServices;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="presenter"></param>
        public ServicosBarbeirosControllers(IServicosBarbeirosPresenter presenter, IMemoryCache memoryCache, IBarbeirosServices barbeirosServices)
        {
            this._presenter = presenter;
            this._barbeirosServices = barbeirosServices;
            this._memoryCache = memoryCache;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="relacionamentoDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostRelacionamentoAsync(ServicosBarbeirosRequestDto relacionamentoDto)
        {
            try
            {

                var result = await _presenter.PostServicoBarbeirosAsync(relacionamentoDto);


                return Created($"/api/v1/barbeirosservicos/", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPost("todosbarbeirostodosservicos")]
        public async Task<IActionResult> PostTodosBarbeiroTodosServicos(Guid tenant)
        {
            try
            {
                return Ok(await _barbeirosServices.PostTodosBarbeiroTodosServicos(tenant));
            }catch (Exception ex)
            { 
                return BadRequest(ex);
            }
        }






    }
}
