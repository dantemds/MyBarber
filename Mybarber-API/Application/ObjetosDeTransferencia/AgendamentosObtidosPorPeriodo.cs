using Aplicacao.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.ObjetosDeTransferencia
{
    public class AgendamentosObtidosPorPeriodo
    {
        public ServicoRelatorio Servico { get; set; }
        public BarbeiroRelatorio Barbeiro { get; set; }

        public AgendamentosObtidosPorPeriodo(ServicoRelatorio servico, BarbeiroRelatorio barbeiro)
        {
            Servico = servico;
            Barbeiro = barbeiro;
        }
    }
}
