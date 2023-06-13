using Aplicacao.Comandos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test.TestesAplicacao.Comando
{
    internal class TesteGerarRelatorioGeralPdf
    {
        [Test]
        public void Deve_Criar_Comando()
        {
            ComandoGerarRelatorioGeralPdf comando = new ComandoGerarRelatorioGeralPdf(new DateTime(), new DateTime(), new Guid());
            Assert.AreNotEqual(comando, null);
        }
    }
}
