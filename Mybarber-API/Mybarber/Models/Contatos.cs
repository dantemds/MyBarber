using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Models
{
    public class Contatos
    {
        [Key()]
        public Guid IdContato { get; set; } = Guid.NewGuid();

        public List<string> Celulares { get; set; }
        public List<string> Telefones { get; set; }
        public List<string> Emails { get; set; }
        public List<string> Instagrams { get; set; }
        public List<string> Outros { get; set; }

        [ForeignKey("Barbearias")]
        public Guid BarbeariasId { get; set; }
        public virtual Barbearias Barbearias  { get; set; }
        

    }
}
