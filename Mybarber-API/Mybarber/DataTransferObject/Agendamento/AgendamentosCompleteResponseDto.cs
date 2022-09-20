using System;

namespace Mybarber.DataTransferObject.Agendamento
{
    public class AgendamentosCompleteResponseDto 
    {
        public Guid IdAgendamento { get; set; }
        public string Name { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public DateTime Horario { get; set; }
        public Guid ServicosId { get; set; }
        public Guid BarbeirosId { get; set; }
        public Guid BarbeariasId { get; set; }
    }
}
