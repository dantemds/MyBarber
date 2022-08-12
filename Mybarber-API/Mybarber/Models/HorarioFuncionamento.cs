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
        public int IdHorarioFuncionamento { get; set; }
        public List<string> Funcionamento { get; set; }
        //[ForeignKey("Barbearias")]
        public int BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }
    }
}
