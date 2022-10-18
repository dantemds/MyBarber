using Mybarber.DataTransferObject.Relacionamento;
using System.Threading.Tasks;

namespace Mybarber.Presenters.Interfaces
{
    public interface IRolesUsersPresenter
    {
        Task<UsersRolesResponseDto> PostRelacionamentoAsync(UsersRolesRequestDto relacionamentoDto);
    }
}
