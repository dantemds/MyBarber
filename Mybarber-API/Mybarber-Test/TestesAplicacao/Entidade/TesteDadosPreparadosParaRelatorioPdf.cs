using Aplicacao.Entidades;
using Aplicacao.ObjetosDeTransferencia;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test.TestesAplicacao.Entidade
{
    internal class TesteDadosPreparadosParaRelatorioPdf
    {
        [Test]
        public void Deve_Criar_Dados_Preparados_Para_Relatorio_PDF()
        {
            BarbeiroRelatorio barbeiro = new BarbeiroRelatorio("João");
            BarbeiroRelatorio barbeiro2 = new BarbeiroRelatorio("José");
            ServicoRelatorio servico = new ServicoRelatorio(30.00f);
            AgendamentosObtidosPorPeriodo agendamentosObtidosPorPeriodo = new AgendamentosObtidosPorPeriodo(servico, barbeiro);
            AgendamentosObtidosPorPeriodo agendamentosObtidosPorPeriodo2 = new AgendamentosObtidosPorPeriodo(servico, barbeiro2);
            ICollection<AgendamentosObtidosPorPeriodo> agendamentosObtidosPorPeriodosList = new List<AgendamentosObtidosPorPeriodo>();
            agendamentosObtidosPorPeriodosList.Add(agendamentosObtidosPorPeriodo);
            agendamentosObtidosPorPeriodosList.Add(agendamentosObtidosPorPeriodo2);
            DadosPreparadosParaRelatorio dadosPreparadosParaRelatorioPdf = new DadosPreparadosParaRelatorio(agendamentosObtidosPorPeriodosList);
            Assert.AreEqual(60.00f, dadosPreparadosParaRelatorioPdf.FaturamentoGeral);
            Assert.AreEqual(2, dadosPreparadosParaRelatorioPdf.ServicosPrestados);
            Assert.AreEqual(2, dadosPreparadosParaRelatorioPdf.BarbeiroRelatorioPdf.Count);
        }
    }
}
