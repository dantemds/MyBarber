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

        Task<BarbeariasCompleteResponseDto> PostBarbeariaAsync(BarbeariasRequestDto barbeariaDto);

        Task<BarbeariasResponseDto> GetAllAtributesBarbeariaAsyncById(int idBarbearia);
        Task<string> DeleteBarbeariaAsyncById(int idBarbearia);
        Task<bool> PutBarbeariaAsyncById(int idBarbearia, BarbeariasRequestDto dto);
    }
}
