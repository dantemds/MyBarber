using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Entidades
{
    public class Salt
    {
        public byte[] SaltByte { get; set; }
        public Salt(string nomeUsuario)
        {
            SaltByte =  Encoding.ASCII.GetBytes(nomeUsuario);
        }
    }
}
