
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Servico;
using System;

namespace Mybarber.DataTransferObject.Agendamento
{
    public class AgendamentosResponseDto 
    {
        public int IdAgendamento { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public DateTime Horario { get; set; }
        public virtual ServicosForAgendamentosDto Servicos { get; set; }
        public virtual BarbeirosForAgendamentosDto Barbeiros { get; set; }

    }
}
