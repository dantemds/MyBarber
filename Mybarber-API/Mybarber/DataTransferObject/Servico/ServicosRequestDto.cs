
using System;

namespace Mybarber.DataTransferObject.Servico
{
    public class ServicosRequestDto 
    {

        public string NomeServico { get; set; }
        public DateTime TempoServico { get; set; }
        public float PrecoServico { get; set; }
        public int BarbeariasId { get; set; }

        public int ServicoImagemId { get; set; }
    }
}
