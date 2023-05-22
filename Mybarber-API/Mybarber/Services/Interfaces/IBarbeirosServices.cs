using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IBarbeirosServices
    {
        //Task<IEnumerable<Barbeiros>> GetAllBarbeirosAsync();
        Task<Barbeiros> GetBarbeiroAsyncById(Guid idBarbeiro);
        Task<IEnumerable<Barbeiros>> GetBarbeiroAsyncByTenant(Guid idBarbearia);
        Task<Barbeiros> PostBarbeiroAsync(Barbeiros barbeiros);
        Task<string> DeleteBarbeiroAsyncById(Guid idBarbeiro);
        Task<bool> UpdateBarbeiroAsyncById(Guid idBarbeiro);
        Task<Barbeiros> PostBarbeiroTodosServicosAsync(BarbeirosRequestDto barbeirosRequestDto);
        Task<bool> PostTodosBarbeiroTodosServicos(Guid tenant);
    }
}
