using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Contatos
{
    public class ContatosRequestDto
    {
        public List<string> Celulares { get; set; }
        public List<string> Telefones { get; set; }
        public List<string> Emails { get; set; }
        public List<string> Instagrams { get; set; }
        public List<string> Outros { get; set; }
        public int BarbeariasId { get; set; }
    }
}
