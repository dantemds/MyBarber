using Aplicacao.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.CasosDeUso.Interfaces
{
    public interface IGerarRelatorioGeralPdf
    {
        public Task<byte[]> Executar(ComandoGerarRelatorioGeralPdf comando);
    }
}
