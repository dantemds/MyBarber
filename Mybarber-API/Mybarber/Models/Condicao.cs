using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mybarber.Models
{
    public class Condicao
    {
        [Key()]
        public int IdCondicao { get; set; }
        public string NomeCondicao { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public virtual ICollection<BarbeariasCondicoes> BarbeariasCondicoes { get; set; }
    }
}
