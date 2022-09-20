

using System;

namespace Mybarber.DataTransferObject.Barbeiro
{
    public class BarbeirosCompleteResponseDto 
    {
        public Guid IdBarbeiro { get; set; }
        public string NameBarbeiro { get; set; }
        public Guid BarbeariasId { get; set; }
    }
}
