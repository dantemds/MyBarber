using Aplicacao.ObjetosDeTransferencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IPrepararDadosParaRelatorioPdf
    {
        public Task<DadosPreparadosParaRelatorioPdf> PrepararDadosParaRelatorioPdf(AgendamentosObtidosPorPeriodo[] agendamentosObtidosPorPeriodo);
    }
}
