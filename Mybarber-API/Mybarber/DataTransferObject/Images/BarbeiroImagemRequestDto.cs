

using System;

namespace Mybarber.DataTransferObject.Images
{
    public class BarbeiroImagemRequestDto
    {
        public string Name { get; set; }
        public Guid BarbeirosId { get; set; }
        public string URL { get; set; }
    }
}
