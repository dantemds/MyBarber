
using System;

namespace Mybarber.DataTransferObject.Servico
{
    public class ServicosForAgendamentosDto 
    {
        public int IdServico { get; set; }
        public string NomeServico { get; set; }
        public DateTime TempoServico { get; set; }
        public float PrecoServico { get; set; }

    }
}
