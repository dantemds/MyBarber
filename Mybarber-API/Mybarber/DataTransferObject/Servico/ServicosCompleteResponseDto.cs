
using Mybarber.Models;
using System;
using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Servico
{
    public class ServicosCompleteResponseDto
    {
        public Guid IdServico { get; set; }
        public string NomeServico { get; set; }
        public DateTime TempoServico { get; set; }
        public float PrecoServico { get; set; }
        public Guid BarbeariasId { get; set; }
        public List<ServicosBarbeiros> ServicosBarbeiros { get; set; }
        public Guid ServicoImagemId { get; set; }
        public string Route { get; set; }
        public int Ordem { get; set; }
    }
    
}
