

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Mybarber.DataTransferObject.Agendamento;
using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Presenter;
using Mybarber.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{ 


    [EnableCors]
    [ApiController]
    [Route("api/v1/agendamentos")]
   
    public class AgendamentosControllers : ControllerBase
    {
        private readonly IAgendamentosPresenter _presenter;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<AgendamentosControllers> _logger;


        public AgendamentosControllers(IAgendamentosPresenter presenter, IAgendamentosRepository repo, IMemoryCache memoryCache,ILogger<AgendamentosControllers> logger)
        {
            this._memoryCache = memoryCache;
           this._logger = logger;
            this._presenter = presenter;
            this._repo = repo;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetAllAgendamentosAsync()
        { 
            
                var result = await _presenter.GetAllAgendamentosAsync();

                return Ok(result);
            }
           
                
            
        
        
        [HttpGet("{idAgendamento:int}")]
        public async Task<IActionResult> GetAgendamentoAsyncById(int idAgendamento)
        {
          
                var result = await _presenter.GetAgendamentoAsyncById(idAgendamento);

                return Ok(result);

           
        }
        
        [HttpPost]
       
        public async Task<IActionResult> PostAgendamentoAsync(AgendamentosRequestDto agendamentoDto)
        {
            try
            {
              
                var result = await _presenter.PostAgendamentoAsync(agendamentoDto);

                return Created($"/api/v1/agendamentos/{result.IdAgendamento}", result);
            }catch(Exception ex)
            { throw new Exception(ex.Message); }
           
        }


        private readonly IAgendamentosRepository _repo;

        

        [HttpGet("tenant/{tenant:int}")]
        public async Task<IActionResult> GetAgendamentosAsyncByTenant(int tenant, [FromQuery] PageParams pageParams)
        {
            
            var key = tenant.ToString() + pageParams.Date.ToString() + pageParams.NomeBarbeiro + pageParams.PageNumber.ToString() + pageParams.NomeServico + pageParams.PageSize.ToString();
         
            
           
            if (_memoryCache.TryGetValue(key, out List<Agendamentos> listaCache))
               return Ok(listaCache);
           
       
           
          

            var result = await _repo.GetAgendamentosAsyncByTenant(tenant, pageParams);

            var memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1),
               SlidingExpiration = TimeSpan.FromSeconds(1)
            };
            
            
          
           
            _memoryCache.Set(key, result, memoryCacheEntryOptions);

                Response.AddPagination(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
         

            return Ok(result);
           

        }
        [HttpDelete("{idAgendamento:int}")]
        public async Task<IActionResult> DeleteAgendamentoById(int idAgendamento)
        {


            await _presenter.DeleteAgendamentoAsyncById(idAgendamento);

            return Ok();


        }


    }
}
