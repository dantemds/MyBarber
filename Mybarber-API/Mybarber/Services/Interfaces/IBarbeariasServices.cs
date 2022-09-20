using Mybarber.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IBarbeariasServices
    {
        //Task<IEnumerable<Barbearias>> GetAllBarbeariasAsync();
        Task<Barbearias> GetBarbeariaAsyncById(Guid idBarbearia);

        Task<Barbearias> PostBarbeariaAsync(Barbearias barbearias);
        Task<string> DeleteBarbeariaAsyncById(Guid idBarbearia);
        Task<bool> PutBarbeariaAsyncById(Guid idBarbearia, Barbearias barbearias);
        Task<Barbearias> GetBarbeariaAsyncByRoute(string route);

    }
}
