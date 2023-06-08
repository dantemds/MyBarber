using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Comandos
{
    public class ComandoGerarRelatorioJson
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Guid IdBarbearia { get; set; }

        public ComandoGerarRelatorioJson(DateTime dataInicio, DateTime dataFim, Guid idBarbearia)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            IdBarbearia = idBarbearia;
        }
    }
}
