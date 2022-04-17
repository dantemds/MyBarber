using Mybarber.DataTransferObject.Barbeiro;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Mybarber.Presenter
{
    public interface IBarbeirosPresenter
    {
        //Task<IEnumerable<BarbeirosResponseDto>> GetAllBarbeirosAsync();

        Task<BarbeirosResponseDto> GetBarbeiroAsyncById(int idBarbeiro);

        Task<BarbeirosResponseDto> GetBarbeiroAsyncByTenant(int idBarbearia);

        Task<BarbeirosCompleteResponseDto> PostBarbeiroAsync(BarbeirosRequestDto barbeiroDto);

        Task<string> DeleteBarbeiroAsyncById(int idBarbeiro);
       

    }
}
