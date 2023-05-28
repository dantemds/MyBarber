using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Comandos
{
    public class ComandoGerarRelatorioGeralPdf
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public ComandoGerarRelatorioGeralPdf(DateTime dataInicio, DateTime dataFim)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
        }
    }
}
