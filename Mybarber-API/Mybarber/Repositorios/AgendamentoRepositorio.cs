using Aplicacao.Interfaces;
using Aplicacao.ObjetosDeTransferencia;
using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositorios
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private readonly Context _contexto;

        public AgendamentoRepositorio(Context context)
        {
            _contexto = context;
        }
        public async Task<AgendamentosObtidosPorPeriodo[]> ObterAgendamentosPorPeriodo(DateTime inicio, DateTime fim)
        {
            IQueryable<Agendamentos> query = _contexto.Agendamentos.Include(a => a.Barbeiros).Include(a => a.Servicos);
            query = query.AsNoTracking()
                       .OrderBy(a => a.Horario)
                       .Where(a => a.Horario > inicio && a.Horario < fim);
            Agendamentos[]? agendamentos = await query.ToArrayAsync();




        }
    }
}
