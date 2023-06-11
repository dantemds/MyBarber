using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.ObjetosDeTransferencia
{
    public class DadosPreparadosParaRelatorio
    {
        public double FaturamentoGeral { get; set; }
        public int ServicosPrestados { get; set; }
        public ICollection<BarbeiroRelatorioPdf> BarbeiroRelatorioPdf { get; set; } = new List<BarbeiroRelatorioPdf>();

        public DadosPreparadosParaRelatorio(ICollection<AgendamentosObtidosPorPeriodo> agendamentosObtidosPorPeriodo)
        {
            this.PrepararDados(agendamentosObtidosPorPeriodo);
        }

        private void PrepararDados(ICollection<AgendamentosObtidosPorPeriodo> agendamentosObtidosPorPeriodo)
        {
            IList<BarbeiroRelatorioPdf> BarbeiroRelatorioPdf = new List<BarbeiroRelatorioPdf>();
            foreach (var agendamento in agendamentosObtidosPorPeriodo)
            {
                this.FaturamentoGeral += agendamento.Servico.PrecoServico;
                this.ServicosPrestados++;
                BarbeiroRelatorioPdf barbeiro = BarbeiroRelatorioPdf.Where(b => b.NomeBarbeiro == agendamento.Barbeiro.NomeBarbeiro).FirstOrDefault();
               
                barbeiro.Faturamento += agendamento.Servico.PrecoServico;
                barbeiro.NumeroServicos++;
                if (barbeiro.NomeBarbeiro == null)
                {
                    barbeiro.NomeBarbeiro = agendamento.Barbeiro.NomeBarbeiro;
                    barbeiro.Porcentagem = agendamento.Barbeiro.Porcentagem;
                    BarbeiroRelatorioPdf.Add(barbeiro);
                } else
                {
                    BarbeiroRelatorioPdf barbeiroEncontrado = BarbeiroRelatorioPdf.Where(b => b.NomeBarbeiro == agendamento.Barbeiro.NomeBarbeiro).FirstOrDefault();
                    int index = BarbeiroRelatorioPdf.IndexOf(barbeiroEncontrado);
                    BarbeiroRelatorioPdf[index] = barbeiro;
                }
            }
            BarbeiroRelatorioPdf = BarbeiroRelatorioPdf.OrderByDescending(objeto => objeto.Faturamento).ToList();
            this.BarbeiroRelatorioPdf = BarbeiroRelatorioPdf;
        }
    }
}
