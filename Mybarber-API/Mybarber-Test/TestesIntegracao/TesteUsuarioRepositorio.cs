using Aplicacao.Interfaces;
using Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Mybarber_Test.TestesIntegracao
{
    internal class TesteUsuarioRepositorio
    {
        private Context _context;
        private IUsuarioRepositorio _usuarioRepositorio;
        [SetUp]
        public void Inicializador()
        {
            DbContextOptionsBuilder<Context> conexao = new DbContextOptionsBuilder<Context>();
            conexao.UseInMemoryDatabase("Banco");
            var opcao = conexao.Options;

            _context = new Context(opcao);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            Users user = new Users()
            {
                Email = "email@email.com",
                UserName = "José",
                Password = "1234"
            };
            _context.Add(user);
            _context.SaveChanges();
            _usuarioRepositorio = new UsuarioRepositorio(_context);
        }
        [Test]
        public async Task Deve_Obter_Usuario_Por_Email()
        {
            var usuario = await _usuarioRepositorio.ObterUsuarioPorEmail("email@email.com");
            Assert.AreNotEqual(usuario, null);
        }
    }
}
