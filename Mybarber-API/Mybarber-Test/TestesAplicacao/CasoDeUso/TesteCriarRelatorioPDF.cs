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
            GerarRelatorioPDF geradorRelatorioPDF = new GerarRelatorioPDF();
            geradorRelatorioPDF.GerarRelatorio();
        }
    }
}
