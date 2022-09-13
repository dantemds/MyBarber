using Mybarber.DataTransferObject.Barbearia;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Servico;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenter
{
    public interface IBarbeariasPresenter
    {

        //Task<IEnumerable<BarbeariasResponseDto>> GetAllBarbeariasAsync();

        //Task<BarbeariasResponseDto> GetBarbeariaAsyncById(int idBarbearia);
        Task<BarbeariasResponseDto> GetAllAtributesBarbeariaAsyncByRoute(string route);
        Task<BarbeariasCompleteResponseDto> PostBarbeariaAsync(BarbeariasRequestDto barbeariaDto);

        Task<BarbeariasResponseDto> GetAllAtributesBarbeariaAsyncById(Guid idBarbearia);
        Task<string> DeleteBarbeariaAsyncById(Guid idBarbearia);
        Task<bool> PutBarbeariaAsyncById(Guid idBarbearia, BarbeariasRequestDto dto);
    }
}
