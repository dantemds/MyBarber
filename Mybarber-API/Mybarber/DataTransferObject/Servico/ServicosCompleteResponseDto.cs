
using Mybarber.Models;
using System;
using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Servico
{
    public class ServicosCompleteResponseDto
    {
        public int IdServico { get; set; }
        public string NomeServico { get; set; }
        public DateTime TempoServico { get; set; }
        public float PrecoServico { get; set; }
        public int BarbeariasId { get; set; }
        public List<ServicosBarbeiros> ServicosBarbeiros { get; set; }
        public int ServicoImagemId { get; set; }
    }
    
}
