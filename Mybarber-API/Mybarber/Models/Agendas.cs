using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class Agendas
    {
        [Key()]
        public int IdAgendas { get; set; }
        public List<float> Segunda { get; set; }

        public List<float> Terca { get; set; }

        public List<float> Quarta { get; set; }

        public List<float> Quinta { get; set; }

        public List<float> Sexta { get; set; }

        public List<float> Sabado { get; set; }

        public List<float> Domingo { get; set; }

        public int BarbeirosId { get; set; }

        public Barbeiros Barbeiros { get; set; }

        [ForeignKey("Barbearias")]
        public int BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }

    }
}