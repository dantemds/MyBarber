using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class Aviso
    {
        [Key]
        public int IdAviso { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public bool Ativo { get; set; }
        [ForeignKey("Barbearias")]
        public Guid BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }

    }
}
