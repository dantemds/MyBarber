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
        private readonly IPrepararDadosParaRelatorioPdf _prepararDadosParaRelatorioPdf;
        private readonly IGerarRelatorioPdf _gerarRelatorio;

        public GerarRelatorioGeralPdf(IAgendamentoRepositorio agendamentoRepositorio, IPrepararDadosParaRelatorioPdf prepararDadosParaRelatorioPdf, IGerarRelatorioPdf gerarRelatorio)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
            _prepararDadosParaRelatorioPdf = prepararDadosParaRelatorioPdf;
            _gerarRelatorio = gerarRelatorio;  
        }

        public async Task Executar(ComandoGerarRelatorioGeralPdf comando)
        {
            AgendamentosObtidosPorPeriodo[] agendamentosObtidosPorPeriodos = await _agendamentoRepositorio.ObterAgendamentosPorPeriodo(comando.DataInicio, comando.DataFim);

            DadosPreparadosParaRelatorioPdf dadosPreparadosParaRelatorioPdf = await _prepararDadosParaRelatorioPdf.PrepararDadosParaRelatorioPdf(agendamentosObtidosPorPeriodos);

            _gerarRelatorio.GerarRelatorio();


        }
    }
}
