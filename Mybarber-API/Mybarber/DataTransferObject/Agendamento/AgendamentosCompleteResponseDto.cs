using System;

namespace Mybarber.DataTransferObject.Agendamento
{
    public class AgendamentosCompleteResponseDto 
    {
        public int IdAgendamento { get; set; }
        public string Name { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public DateTime Horario { get; set; }
        public int ServicosId { get; set; }
        public int BarbeirosId { get; set; }
        public int BarbeariasId { get; set; }
    }
}
