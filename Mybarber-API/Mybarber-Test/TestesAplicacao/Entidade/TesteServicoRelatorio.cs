using Aplicacao.Entidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test.TestesAplicacao.Entidade
{
    public class TesteServicoRelatorio
    {
        [Test]
        public void Deve_Criar_Servico_Relatorio()
        {
           ServicoRelatorio servicoRelatorio = new ServicoRelatorio(30.00f);
           Assert.IsNotNull(servicoRelatorio);
        }
    }
}
