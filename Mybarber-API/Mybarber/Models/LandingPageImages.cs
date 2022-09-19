using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class LandingPageImages
    {
        [Key()]
        public Guid IdLandingPageImage { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }

        [ForeignKey("Barbearias")]
        public Guid BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }
    }
}
