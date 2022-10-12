

using System;

namespace Mybarber.DataTransferObject.Images
{
    public class ServicoImagemResponseDto 
    {
        public Guid IdImagemServico { get; set; }

        public string URL { get; set; }
        public Guid ServicosId { get; set; }
    }
}
