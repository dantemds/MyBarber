using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.DataTransferObject.Agendamento
{
    public class AgendamentosResponseGetAgendamentoByTenantDTO
    {

        public int IdAgendamento { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public DateTime Horario { get; set; }
        public int ServicosId { get; set; }
        public int BarbeirosId { get; set; }
    }
}
