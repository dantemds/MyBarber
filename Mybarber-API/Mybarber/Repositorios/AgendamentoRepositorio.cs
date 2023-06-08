using Aplicacao.Entidades;
using Aplicacao.Interfaces;
using Aplicacao.ObjetosDeTransferencia;
using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using System;
using System.Collections.Generic;
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
        public async Task<ICollection<AgendamentosObtidosPorPeriodo>> ObterAgendamentosPorPeriodo(DateTime inicio, DateTime fim, Guid idBarbearia)
        {
            IQueryable<Agendamentos> query = _contexto.Agendamentos.Include(a => a.Barbeiros).ThenInclude(b=>b.Comissao).Include(a => a.Servicos);
            query = query.AsNoTracking()
                       .OrderBy(a => a.Horario)
                       .Where(a => a.Horario > inicio && a.Horario < fim && a.BarbeariasId == idBarbearia);
            Agendamentos[]? agendamentos = await query.ToArrayAsync();
            ICollection<AgendamentosObtidosPorPeriodo> agendamentosObtidosPorPeriodosList = new List<AgendamentosObtidosPorPeriodo>();
            foreach (Agendamentos agendamento in agendamentos)
            {
                if (agendamento.Barbeiros.Comissao == null)
                {
                    agendamento.Barbeiros.Comissao = new Comissao(0, 0, agendamento.Barbeiros.IdBarbeiro, agendamento.Barbeiros);
                }
                BarbeiroRelatorio barbeiro = new BarbeiroRelatorio(agendamento.Barbeiros.NameBarbeiro, agendamento.Barbeiros.Comissao.Porcentagem);
                ServicoRelatorio servico = new ServicoRelatorio(agendamento.Servicos.PrecoServico);
                AgendamentosObtidosPorPeriodo agendamentosObtidosPorPeriodo = new AgendamentosObtidosPorPeriodo(servico, barbeiro);
                agendamentosObtidosPorPeriodosList.Add(agendamentosObtidosPorPeriodo);
            }
            return agendamentosObtidosPorPeriodosList;
        }
    }
}
