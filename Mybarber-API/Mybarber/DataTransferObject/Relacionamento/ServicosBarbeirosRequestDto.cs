

using System;

namespace Mybarber.DataTransferObject.Relacionamento
{
    public class ServicosBarbeirosRequestDto 
    {
        public Guid ServicosId { get; set; }

        public Guid BarbeirosId { get; set; }

        public Guid BarbeariasId { get; set; }
    }
}
