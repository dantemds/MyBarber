using System;

namespace Mybarber.DataTransferObject.EventoAgendado
{
    public class EventoAgendadoRequestDto
    {
        public string NomeEvento { get; set; }
        public string DescricaoEvento { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public string DiaSemana { get; set; }
        public bool Temporario { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public Guid BarbeirosId { get; set; }
        public Guid BarbeariasId { get; set; }
    }
}
