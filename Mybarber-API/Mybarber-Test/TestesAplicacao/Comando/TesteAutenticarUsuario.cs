using Aplicacao.Comandos;
using NUnit.Framework;


namespace Mybarber_Test.TestesAplicacao.Comando
{
    internal class TesteAutenticarUsuario
    {
        [Test]
        public void Deve_Criar_Comando_Autenticar_Usuario()
        {
            ComandoAutenticarUsuario comando = new ComandoAutenticarUsuario("email@email.com", "123456");
            Assert.AreNotEqual(comando, null);
        }
    }
}
