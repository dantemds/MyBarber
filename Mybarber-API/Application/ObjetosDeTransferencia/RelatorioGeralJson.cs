using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.ObjetosDeTransferencia
{
    public class RelatorioGeralJson
    {
        public double ValorFaturado { get; set; }
        public int NumeroServicoTotal { get; set; }
        public ICollection<BarbeiroRelatorioPdf> DadosBarbeiros { get; set; }

        public RelatorioGeralJson(double valorFaturado, int numeroServicoTotal, ICollection<BarbeiroRelatorioPdf> dadosBarbeiros)
        {
            ValorFaturado = valorFaturado;
            NumeroServicoTotal = numeroServicoTotal;
            DadosBarbeiros = dadosBarbeiros;
            this.GerarComissoes();
        }

        public void GerarComissoes()
        {
            IList<BarbeiroRelatorioPdf> dadosBarbeiros = new List<BarbeiroRelatorioPdf>();
            foreach (BarbeiroRelatorioPdf dados in DadosBarbeiros)
            {
                dados.ObterComissao();
                dadosBarbeiros.Add(dados);
            }
            this.DadosBarbeiros = dadosBarbeiros;
        }
    }
}
