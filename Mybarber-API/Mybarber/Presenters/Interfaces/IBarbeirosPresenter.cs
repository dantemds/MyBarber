using Mybarber.DataTransferObject.Barbeiro;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Mybarber.Presenter
{
    public interface IBarbeirosPresenter
    {
        //Task<IEnumerable<BarbeirosResponseDto>> GetAllBarbeirosAsync();

        Task<BarbeirosResponseDto> GetBarbeiroAsyncById(Guid idBarbeiro);

        Task<List<BarbeirosResponseDto>> GetBarbeiroAsyncByTenant(Guid idBarbearia);

        Task<BarbeirosCompleteResponseDto> PostBarbeiroAsync(BarbeirosRequestDto barbeiroDto);

        Task<BarbeirosCompleteResponseDto> DeleteBarbeiroAsyncById(Guid idBarbeiro);
        Task<BarbeirosCompleteResponseDto> PostBarbeiroTodosServicosAsync(BarbeirosRequestDto barbeiroDto);



    }
}
