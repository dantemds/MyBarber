using System;
using System.ComponentModel.DataAnnotations;

namespace Mybarber.Models
{
    public class Comissao
    {

        [Key()]
        public int IdComissao { get; set; }
        public double Porcentagem { get; set; }
        public Guid BarbeirosId { get; set; }
        public Barbeiros Barbeiros { get; set; }

        public Comissao(int idComissao, double porcentagem, Guid barbeirosId, Barbeiros barbeiros)
        {
            IdComissao = idComissao;
            Porcentagem = porcentagem;
            BarbeirosId = barbeirosId;
            Barbeiros = barbeiros;
        }

        public Comissao()
        {

        }
    }
}
