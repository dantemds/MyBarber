using Mybarber.Helpers;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test
{
    public class VerificarSenhaTeste
    {
        [Test]
        public void Deve_Validar_Senha()
        {
            var newHash = HashPassword(password);
            return this.Password.SequenceEqual(newHash);
        }
    }
}
