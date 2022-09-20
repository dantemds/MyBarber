
using System;

namespace Mybarber.DataTransferObject.Agendamento
{
    public class AgendamentosRequestDto 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public DateTime Horario { get; set; }
        public Guid ServicosId { get; set; }
        public Guid BarbeirosId { get; set; }
        public Guid BarbeariasId { get; set; }
    }
}
