using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.DataTransferObject.Agendamento
{
    public class AgendamentosDoBarbeiro
    {
        public Guid IdAgendamento { get; set; }
        public DateTime HorarioAgendamento { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public float PrecoServico { get; set; }
        public string NomeCliente { get; set; }
        public string NomeServico { get; set; }
    }
}
