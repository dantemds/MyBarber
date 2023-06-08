using Aplicacao.CasosDeUso.Interfaces;
using Aplicacao.Comandos;
using Aplicacao.Interfaces;
using Aplicacao.ObjetosDeTransferencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.CasosDeUso
{
    public class GerarRelatorioGeralJson : IGerarRelatorioGeralJson
    {
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;

        public GerarRelatorioGeralJson(IAgendamentoRepositorio agendamentoRepositorio)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
        }

        public async Task<RelatorioGeralJson> Executar(ComandoGerarRelatorioJson comando)
        {
            ICollection<AgendamentosObtidosPorPeriodo> agendamentosObtidosPorPeriodo = await _agendamentoRepositorio.ObterAgendamentosPorPeriodo(comando.DataInicio, comando.DataFim, comando.IdBarbearia);

            DadosPreparadosParaRelatorio dadosPreparadosParaRelatorioPdf = new DadosPreparadosParaRelatorio(agendamentosObtidosPorPeriodo);

            RelatorioGeralJson relatorioGeralJson = new RelatorioGeralJson(dadosPreparadosParaRelatorioPdf.FaturamentoGeral, dadosPreparadosParaRelatorioPdf.ServicosPrestados, dadosPreparadosParaRelatorioPdf.BarbeiroRelatorioPdf);

            return relatorioGeralJson;
        }
    }
}
