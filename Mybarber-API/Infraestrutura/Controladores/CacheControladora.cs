using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Infraestrutura.Controladores
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/cache")]
    public class CacheControladora : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public CacheControladora(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public IActionResult RemoverCacheBarbearia(string rota)
        {
            try
            {
                if (_memoryCache.TryGetValue(rota, out var barbeariaCache))
                {
                    _memoryCache.Remove(rota);

                }
                return Ok();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return BadRequest(ex.Message);
            }
            
        }
    }
}
