using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repositories.Interface
{
    public interface IEventoRepository
    {
        Task<EventoAgendado> GetAgendamentosAsyncById(int idEvento);
    }
}
