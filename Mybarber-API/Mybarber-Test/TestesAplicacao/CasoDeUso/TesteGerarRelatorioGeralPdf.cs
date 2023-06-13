using Aplicacao.CasosDeUso;
using Aplicacao.Comandos;
using Aplicacao.Interfaces;
using Infraestrutura.Relatorio;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test.TestesAplicacao.CasoDeUso
{
    public class TesteGerarRelatorioGeralPdf
    {
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        private readonly GerarRelatorioGeralPdf _gerarRelatorioGeralPdf;
        private readonly GerarRelatorioPDF _gerarRelatorioPDF;
        public TesteGerarRelatorioGeralPdf()
        {
            _agendamentoRepositorio = Substitute.For<IAgendamentoRepositorio>();
            _gerarRelatorioPDF = new GerarRelatorioPDF();
            _gerarRelatorioGeralPdf = new GerarRelatorioGeralPdf(_agendamentoRepositorio, _gerarRelatorioPDF);
        }
        [Test]
        public async Task Deve_Gerar_Relatorio_Geral_PDF()
        {
            DateTime inicio = new DateTime(2023, 1, 1);
            DateTime fim = new DateTime(2023, 5, 1);
            ComandoGerarRelatorioGeralPdf comando = new ComandoGerarRelatorioGeralPdf(inicio, fim, new Guid("f6df7a5a - 56eb - 499d - be20 - fa1ae344b2d7"));
            await _gerarRelatorioGeralPdf.Executar(comando);
        }

    }
}
