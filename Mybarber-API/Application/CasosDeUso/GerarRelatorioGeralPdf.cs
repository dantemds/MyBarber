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
    public class GerarRelatorioGeralPdf : IGerarRelatorioGeralPdf
    {
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        private readonly IGerarRelatorioPdf _gerarRelatorio;

        public GerarRelatorioGeralPdf(IAgendamentoRepositorio agendamentoRepositorio, IGerarRelatorioPdf gerarRelatorio)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
            _gerarRelatorio = gerarRelatorio;  
        }

        public async Task Executar(ComandoGerarRelatorioGeralPdf comando)
        {
            ICollection<AgendamentosObtidosPorPeriodo> agendamentosObtidosPorPeriodo = await _agendamentoRepositorio.ObterAgendamentosPorPeriodo(comando.DataInicio, comando.DataFim, comando.IdBarbearia);

            DadosPreparadosParaRelatorioPdf dadosPreparadosParaRelatorioPdf = new DadosPreparadosParaRelatorioPdf(agendamentosObtidosPorPeriodo);

            _gerarRelatorio.GerarRelatorio(dadosPreparadosParaRelatorioPdf);


        }
    }
}
