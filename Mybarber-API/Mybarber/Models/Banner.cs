using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class Banner
    {
        [Key()]
        public Guid IdBanner { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string URL { get; set; }

        [ForeignKey("Barbearias")]
        public Guid BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }
    }
}
