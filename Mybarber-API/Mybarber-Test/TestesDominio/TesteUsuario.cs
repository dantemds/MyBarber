using Dominio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test.TestesDominio
{
    public class TesteUsuario
    {
        [Test]
        public void Deve_Criar_Usuario()
        {
            Usuario usuario = new Usuario(new Guid(), "Joãos", "email@email.com", "123456");
            Assert.AreNotEqual(usuario, null);
        }
    }
}
