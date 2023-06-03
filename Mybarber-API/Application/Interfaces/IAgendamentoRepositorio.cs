using Aplicacao.ObjetosDeTransferencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAgendamentoRepositorio
    {
        public Task<ICollection<AgendamentosObtidosPorPeriodo>> ObterAgendamentosPorPeriodo(DateTime inicio, DateTime fim);
    }
}
