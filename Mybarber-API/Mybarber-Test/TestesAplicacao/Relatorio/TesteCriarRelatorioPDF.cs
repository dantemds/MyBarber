using Aplicacao.CasosDeUso;
using Aplicacao.CasosDeUso.Interfaces;
using Aplicacao.Comandos;
using Aplicacao.Entidades;
using Aplicacao.ObjetosDeTransferencia;
using Infraestrutura.Relatorio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test.TestesAplicacao.CasoDeUso
{
    internal class TesteCriarRelatorioPDF
    {

        [Test]
        public void Deve_Criar_Relatorio()
        {
            GerarRelatorioPDF gerarRelatorio = new GerarRelatorioPDF();
            BarbeiroRelatorio barbeiro = new BarbeiroRelatorio("João");
            ServicoRelatorio servico = new ServicoRelatorio(30.00f);
            AgendamentosObtidosPorPeriodo agendamentosObtidosPorPeriodo = new AgendamentosObtidosPorPeriodo(servico, barbeiro);
            ICollection<AgendamentosObtidosPorPeriodo> agendamentosObtidosPorPeriodosList = new List<AgendamentosObtidosPorPeriodo>();
            agendamentosObtidosPorPeriodosList.Add(agendamentosObtidosPorPeriodo);
            DadosPreparadosParaRelatorio dadosPreparadosParaRelatorioPdf = new DadosPreparadosParaRelatorio(agendamentosObtidosPorPeriodosList);
            gerarRelatorio.GerarRelatorio(dadosPreparadosParaRelatorioPdf);
        }
    }
}
