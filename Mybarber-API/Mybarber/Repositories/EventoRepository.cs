using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repositories.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class EventoRepository:IEventoRepository
    {
        private readonly Context _context;



        public EventoRepository(Context context)
        {
            _context = context;

        }

        public async Task<EventoAgendado> GetAgendamentosAsyncById(int idEvento)
        {
            IQueryable<EventoAgendado> query = _context.EventoAgendado;

            query = query.AsNoTracking()
                .OrderBy(evento => evento.IdEventoAgendado)
                .Where(evento => evento.IdEventoAgendado == idEvento);

            return await query.FirstOrDefaultAsync();
        }

    }
}
