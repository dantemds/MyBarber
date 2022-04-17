
using Microsoft.EntityFrameworkCore;
using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class AgendamentosRepository : IAgendamentosRepository
    {
        private readonly Context _context;

        public AgendamentosRepository(Context context)
        {
            _context = context;
        }

        //-----------------------------------------------------------------------------------------------------//

        public async Task<Agendamentos> GetAgendamentosAsyncById(int idAgendamento)
        {
            IQueryable<Agendamentos> query = _context.Agendamentos.Include(it=>it.Servicos).Include(it=>it.Barbeiros);

            query = query.AsNoTracking()
                .OrderBy(agendamentos => agendamentos.IdAgendamento)
                .Where(agendamentos => agendamentos.IdAgendamento == idAgendamento);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Agendamentos[]> GetAllAgendamentosAsync()
        {
            IQueryable<Agendamentos> query = _context.Agendamentos;

            query = query.AsNoTracking()
                         .OrderBy(agendamentos => agendamentos.IdAgendamento);

            return await query.ToArrayAsync();
        }
          public async Task<PageList<Agendamentos>> GetAgendamentosAsyncByTenant(int tenant, PageParams pageParams )
        {
            IQueryable<Agendamentos> query = _context.Agendamentos.Include(it => it.Servicos).Include(it=>it.Barbeiros);

           // var lisa = from a in _context.Agendamentos where a.IdAgendamento > 1 select a; Sintaxe alternativa

            query = query.AsNoTracking()
                         .OrderBy(agendamentos => agendamentos.Horario)
                         .Where(it => it.BarbeariasId == tenant );


            if (!string.IsNullOrEmpty(pageParams.NomeBarbeiro))
                query = query.Where(agendamento => agendamento.Barbeiros.NameBarbeiro.ToUpper().Equals(pageParams.NomeBarbeiro.ToUpper()));

            if (!string.IsNullOrEmpty(pageParams.NomeServico))
                query = query.Where(agendamento => agendamento.Servicos.NomeServico.ToUpper().Equals(pageParams.NomeServico.ToUpper()));

            if ((pageParams.Date.Day.Equals(DateTime.Now.Day)) && (pageParams.Date.Month.Equals(DateTime.Now.Month)) && (pageParams.Date.Year.Equals(DateTime.Now.Year)))
                query = query.Where
                (agendamento => (agendamento.Horario.Day.Equals(pageParams.Date.Day) && agendamento.Horario.Month.Equals(pageParams.Date.Month)
                && agendamento.Horario.Year.Equals(pageParams.Date.Year)));


                //|| (agendamento.Horario.Day.Equals(pageParams.Date.AddDays(1).Day) && agendamento.Horario.Month.Equals(pageParams.Date.Month)
                //&& agendamento.Horario.Year.Equals(pageParams.Date.Year))
                //|| (agendamento.Horario.Day.Equals(pageParams.Date.AddDays(2).Day) && agendamento.Horario.Month.Equals(pageParams.Date.Month)
                //&& agendamento.Horario.Year.Equals(pageParams.Date.Year))); ;
                    
               
          

            if (!pageParams.Date.Day.Equals(DateTime.Now.Day))
                query = query.Where(agendamentos => agendamentos.Horario.Day.Equals(pageParams.Date.Day) 
                && agendamentos.Horario.Month.Equals(pageParams.Date.Month) && agendamentos.Horario.Year.Equals(pageParams.Date.Year));


                // return await query.ToArrayAsync();

                return await PageList<Agendamentos>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }
        public async Task<Agendamentos> GetAgendamentosAsyncByHorario(Agendamentos horario)
        {
            IQueryable<Agendamentos> query = _context.Agendamentos;

            query = query.AsNoTracking()
                        .OrderBy(a => a.IdAgendamento)
                        .Where(agendamentos => (agendamentos.Horario.Day.Equals(horario.Horario.Day))
                        && (agendamentos.Horario.Month.Equals(horario.Horario.Month))
                        && (agendamentos.Horario.Year.Equals(horario.Horario.Year))
                        && (agendamentos.Horario.Hour.Equals(horario.Horario.Hour))
                        && (agendamentos.Horario.Minute.Equals(horario.Horario.Minute))
                        && (agendamentos.BarbeirosId.Equals(horario.BarbeirosId)));
                       


             return await query.FirstOrDefaultAsync();

        }


    }
}
