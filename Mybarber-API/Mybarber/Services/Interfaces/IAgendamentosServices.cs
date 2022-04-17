using Mybarber.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IAgendamentosServices
    {
        Task<IEnumerable<Agendamentos>> GetAllAgendamentosAsync();
        Task<Agendamentos> GetAgendamentoAsyncById(int idAgendamento);
        Task<Agendamentos> PostAgendamentoAsync(Agendamentos agendamentos);
        Task<bool> DeleteAgendamentoAsync(int idAgendamento);
    }
}
