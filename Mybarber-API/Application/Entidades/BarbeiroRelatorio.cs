using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Entidades
{
    public class BarbeiroRelatorio
    {
        public string NomeBarbeiro { get; set; }

        public BarbeiroRelatorio(string nomeBarbeiro)
        {
            NomeBarbeiro = nomeBarbeiro;
        }
    }
}
