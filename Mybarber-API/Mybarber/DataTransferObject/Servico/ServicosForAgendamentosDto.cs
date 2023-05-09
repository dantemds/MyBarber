
using System;

namespace Mybarber.DataTransferObject.Servico
{
    public class ServicosForAgendamentosDto 
    {
        public Guid IdServico { get; set; }
        public string NomeServico { get; set; }
        public DateTime TempoServico { get; set; }
        public float PrecoServico { get; set; }
        public int Ordem { get; set; }


    }
}
