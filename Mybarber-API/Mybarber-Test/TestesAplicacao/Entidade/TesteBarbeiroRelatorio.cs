using Aplicacao.Entidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test.TestesAplicacao.Entidade
{
    public class TesteBarbeiroRelatorio
    {
        [Test]
        public void Deve_Criar_Barbeiro_Relatorio()
        {
            BarbeiroRelatorio barbeiroRelatorio = new BarbeiroRelatorio("João", 0.5);
            Assert.AreNotEqual(barbeiroRelatorio, null);
        }
    }
}
