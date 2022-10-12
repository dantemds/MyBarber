

using System;

namespace Mybarber.DataTransferObject.Images
{
    public class ServicoImagemRequestDto 
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public Guid ServicosId { get; set; }
    }
}
