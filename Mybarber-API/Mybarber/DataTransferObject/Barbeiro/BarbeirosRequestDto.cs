

using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Barbeiro
{
    public class BarbeirosRequestDto 
    {

        public string Email { get; set; }
        public string NameBarbeiro { get; set; }
        public int BarbeariasId { get; set; }
        public int BarbeiroImagemId { get; set; }
        public string Password { get; set; }

        public ICollection<int> ServicosId { get; set; }
    }
}
