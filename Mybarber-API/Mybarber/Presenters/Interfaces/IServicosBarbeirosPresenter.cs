using Mybarber.DataTransferObject.Relacionamento;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public interface IServicosBarbeirosPresenter
    {
        Task<ServicosBarbeirosRequestDto> PostServicoBarbeirosAsync(ServicosBarbeirosRequestDto relacionamentoDto);
    }
}
