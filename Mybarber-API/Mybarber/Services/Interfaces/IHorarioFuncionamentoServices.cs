using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IHorarioFuncionamentoServices
    {
        Task<HorarioFuncionamento> PostHorarioAsync(HorarioFuncionamento horario);
    }
}
