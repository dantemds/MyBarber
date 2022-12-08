using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class EventoAgendado
    {
        [Key]
        public int IdEventoAgendado { get; set; }
        public string NomeEvento { get; set; }
        public string DescricaoEvento { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public string DiaSemana { get; set; }
        public bool Temporario { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public TimeSpan Duracao { get; set; }

        [ForeignKey("Barbeiros")]
        public Guid BarbeirosId { get; set; }
        public Barbeiros Barbeiros { get; set; }

        [ForeignKey("Barbearias")]
        public Guid BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }


    }
}
