using Microsoft.EntityFrameworkCore;
using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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

        public async Task<List<EventoAgendado>> GetEventosByBarbeiroAsync(Guid idBarbeiro)
        {
            IQueryable<EventoAgendado> query = _context.EventoAgendado;
            query = query.AsNoTracking()
                .OrderBy(evento => evento.IdEventoAgendado)
                .Where(evento => evento.BarbeirosId == idBarbeiro);
            var result = await query.ToArrayAsync();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            var retorno = new List<EventoAgendado>();
            foreach (var item in result)
            {
                if (!item.Temporario)
                {
                    retorno.Add(item);
                }
                else
                {
                    var dataFimConvert = Convert.ToDateTime(item.DataFim);
                    //var data = Date.GetNow();
                    var data = DateTime.Now;
                    if (dataFimConvert >= data)
                    {
                        retorno.Add(item);
                    }
                }
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            return retorno;
        }

    }
}
