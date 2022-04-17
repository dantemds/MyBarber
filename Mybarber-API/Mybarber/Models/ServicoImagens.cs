using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mybarber.Models
{
    public class ServicoImagens
    {
        [Key()]
        public int IdImagemServico { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public virtual ICollection<Servicos> Servicos { get; set; }

        public ServicoImagens() { }




    }
}
