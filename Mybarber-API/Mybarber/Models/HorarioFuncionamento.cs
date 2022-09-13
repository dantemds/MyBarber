using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Models
{
    public class HorarioFuncionamento
    {
        [Key()]
        public Guid IdHorarioFuncionamento { get; set; } = Guid.NewGuid();
        public List<string> Funcionamento { get; set; }
        //[ForeignKey("Barbearias")]
        public Guid BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }
    }
}
