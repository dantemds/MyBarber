using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.ObjetosDeTransferencia
{
    public class DadosPreparadosParaRelatorioPdf
    {
        public double FaturamentoGeral { get; set; }
        public double ServicosPrestados { get; set; }
        public ICollection<BarbeiroRelatorioPdf> BarbeiroRelatorioPdf { get; set; } = new List<BarbeiroRelatorioPdf>();

        public DadosPreparadosParaRelatorioPdf(ICollection<AgendamentosObtidosPorPeriodo> agendamentosObtidosPorPeriodo)
        {
            this.PrepararDados(agendamentosObtidosPorPeriodo);
        }

        private void PrepararDados(ICollection<AgendamentosObtidosPorPeriodo> agendamentosObtidosPorPeriodo)
        {
            foreach(var agendamento in agendamentosObtidosPorPeriodo)
            {
                this.FaturamentoGeral += agendamento.Servico.PrecoServico;
                this.ServicosPrestados++;
                BarbeiroRelatorioPdf barbeiro = this.BarbeiroRelatorioPdf.Where(b => b.NomeBarbeiro == agendamento.Barbeiro.NomeBarbeiro).FirstOrDefault();
                barbeiro.Faturamento += agendamento.Servico.PrecoServico;
                barbeiro.NumeroServicos++;
                if (barbeiro.NomeBarbeiro == null)
                {
                    barbeiro.NomeBarbeiro = agendamento.Barbeiro.NomeBarbeiro;
                    this.BarbeiroRelatorioPdf.Add(barbeiro);
                }
            }
        }
    }
}
