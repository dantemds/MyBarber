using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Entidades
{
    public class ServicoRelatorio
    {
        public float PrecoServico { get; set; }

        public ServicoRelatorio(float precoServico)
        {
            PrecoServico = precoServico;
        }
    }
}
