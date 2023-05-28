using NUnit.Framework;
using Aplicacao.Entidades;

namespace Mybarber_Test
{
    public class TesteSalt
    {
        [Test]
        public void Deve_Criar_Salt()
        {
            string nomeUsuario = "NomeTeste";
            Salt salt = new Salt(nomeUsuario);
            Assert.AreNotEqual(null, salt.SaltByte);
        }
    }
}
