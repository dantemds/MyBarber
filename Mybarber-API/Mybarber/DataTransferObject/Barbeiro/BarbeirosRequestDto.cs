

using System;
using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Barbeiro
{
    public class BarbeirosRequestDto 
    {

        public string Email { get; set; }
        public string NameBarbeiro { get; set; }
        public Guid BarbeariasId { get; set; }
        //public Guid BarbeiroImagemId { get; set; }
        public string Password { get; set; }

        public ICollection<Guid> ServicosId { get; set; }
    }
}
