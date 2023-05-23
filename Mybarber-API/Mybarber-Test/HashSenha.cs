using Konscious.Security.Cryptography;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test
{
    public class HashSenha
    {
        [Test]
        public void Deve_Hash_Senha()
        {
            string senha = "senha";
            Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(senha));
            byte[] buffer = Encoding.ASCII.GetBytes("nome");
            argon2.Salt = buffer;
            argon2.DegreeOfParallelism = 1;
            argon2.Iterations = 1;
            argon2.MemorySize = 4;

            byte[] bytes = argon2.GetBytes(16);
            Assert.AreNotEqual(0, bytes.Length);
        }
    }
}
