using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test
{
    public class CriarSalt
    {
        [Test]
        public void Deve_Criar_Salt()
        {
            string nome = "Nome";
            byte[] buffer = Encoding.ASCII.GetBytes(nome);
            Assert.AreNotEqual(0, buffer.Length);
        }
    }
}
