namespace Mybarber.Models
{
    public class ServicosBarbeiros
    {


        public int ServicosId { get; set; }

        public int BarbeirosId { get; set; }

        public virtual Servicos Servicos { get; set; }

        public virtual Barbeiros Barbeiros { get; set; }

        public int BarbeariasId { get; set; }

        public virtual Barbearias Barbearias { get; set; }

        public ServicosBarbeiros(int servicosId, int barbeirosId, int barbeariasId)

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
