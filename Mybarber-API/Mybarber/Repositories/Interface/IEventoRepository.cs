using Mybarber.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Repositories.Interface
{
    public interface IEventoRepository
    {
        Task<EventoAgendado> GetAgendamentosAsyncById(int idEvento);
        Task<List<EventoAgendado>> GetEventosByBarbeiroAsync(Guid idBarbeiro);
    }
}
