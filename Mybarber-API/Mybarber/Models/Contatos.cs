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
        public int IdContato { get; set; }

        public List<string> Celulares { get; set; }
        public List<string> Telefones { get; set; }
        public List<string> Emails { get; set; }
        public List<string> Instagrams { get; set; }
        public List<string> Outros { get; set; }

        //[ForeignKey("Barbearias")]
        public int BarbeariasId { get; set; }
        public virtual Barbearias Barbearias  { get; set; }
        

    }
}
