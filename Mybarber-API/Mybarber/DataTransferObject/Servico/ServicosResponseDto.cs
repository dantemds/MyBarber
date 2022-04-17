
using Mybarber.DataTransferObject.Images;
using Mybarber.DataTransferObject.Relacionamento;
using System;
using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Servico
{
    public class ServicosResponseDto 
    {

        public int IdServico { get; set; }
        public string NomeServico { get; set; }
        public DateTime TempoServico { get; set; }
        public float PrecoServico { get; set; }
        public virtual ServicoImagemResponseDto ServicoImagem { get; set; }

        public virtual ICollection<ServicosBarbeirosResponseDto> ServicosBarbeiros { get; set; }


    }
}
