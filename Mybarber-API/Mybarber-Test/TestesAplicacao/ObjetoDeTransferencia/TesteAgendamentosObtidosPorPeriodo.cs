using Aplicacao.Entidades;
using Aplicacao.ObjetosDeTransferencia;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test.TestesAplicacao.ObjetoDeTransferencia
{
    internal class TesteAgendamentosObtidosPorPeriodo
    {
        [Test]
        public void Deve_Criar_Agendamentos_Obtidos_Por_Periodo()
        {
            BarbeiroRelatorio barbeiro = new BarbeiroRelatorio("João");
            ServicoRelatorio servico = new ServicoRelatorio(30.00f);
            AgendamentosObtidosPorPeriodo agendamentosObtidosPorPeriodo = new AgendamentosObtidosPorPeriodo(servico, barbeiro);
            Assert.IsNotNull(agendamentosObtidosPorPeriodo);
        }
    }
}
