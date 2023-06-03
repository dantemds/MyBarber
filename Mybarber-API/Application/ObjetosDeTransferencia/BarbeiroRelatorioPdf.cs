using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.ObjetosDeTransferencia
{
    public record struct BarbeiroRelatorioPdf
    {
        public string NomeBarbeiro { get; set; }
        public int NumeroServicos { get; set; }
        public float Faturamento { get; set; }

        public BarbeiroRelatorioPdf(string nomeBarbeiro, int numeroServicos, float faturamento)
        {
            NomeBarbeiro = nomeBarbeiro;
            NumeroServicos = numeroServicos;
            Faturamento = faturamento;
        }
    }
}
