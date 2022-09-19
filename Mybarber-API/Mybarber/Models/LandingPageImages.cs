using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class LandingPageImages
    {
        [Key()]
        public Guid IdLandingPageImage { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string URL { get; set; }
        public int NumeroImagem { get; set; }
        public string Posicao { get; set; }
        public string Especificacao { get; set; }

        [ForeignKey("Barbearias")]
        public Guid BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }
    }
}
