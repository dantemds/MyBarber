using Infraestrutura.Controladores;
using Microsoft.Extensions.Caching.Memory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test.TestesControladoras
{
    public class TesteCache
    {
        private readonly IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());
        
        [Test]
        public void Deve_Remover_Cache()
        {
            var cache = new CacheControladora(_memoryCache);
            var resultado =  cache.RemoverCacheBarbearia("Dom-Cicerus");
            Assert.IsNotNull(resultado);
        }
    }
}
