using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.ObjetosDeTransferencia
{
    public class RelatorioGeralPdf
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

        public RelatorioGeralPdf(DateTime inicio, DateTime fim)
        {
            Inicio = inicio;
            Fim = fim;
        }
    }
}
