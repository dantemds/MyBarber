using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class ServicosBarbeiros
    {


        public Guid ServicosId { get; set; }

        public Guid BarbeirosId { get; set; }

        public virtual Servicos Servicos { get; set; }

        public virtual Barbeiros Barbeiros { get; set; }

        
        public Guid BarbeariasId { get; set; }

        public virtual Barbearias Barbearias { get; set; }

        public ServicosBarbeiros(Guid servicosId, Guid barbeirosId, Guid barbeariasId)

        {
            this.ServicosId = servicosId;
            this.BarbeirosId = barbeirosId;
            this.BarbeariasId = barbeariasId;

        }
        public ServicosBarbeiros()
        {

        }











    }
}
