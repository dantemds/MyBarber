using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Models
{
    public class Temas
    {
        [Key()]
        public Guid IdTema { get; set; } = Guid.NewGuid();
        public string CorPrimaria { get; set; }
        public string CorSecundaria { get; set; }
        public string CorTernaria { get; set; }
        public string CorQuartenaria { get; set; }

        [ForeignKey("Barbearias")]
        public Guid BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }
    }
}
