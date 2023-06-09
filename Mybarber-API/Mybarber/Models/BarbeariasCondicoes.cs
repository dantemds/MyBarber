using System;

namespace Mybarber.Models
{
    public class BarbeariasCondicoes
    {
        public int CondicaoId { get; set; }
        public Condicao Condicao { get; set; }
        public Guid BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }
    }
}
