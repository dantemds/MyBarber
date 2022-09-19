using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Contatos
{
    public class ContatosResponseDto
    {
        public List<string> Celulares { get; set; }
        public List<string> Telefones { get; set; }
        public List<string> Emails { get; set; }
        public List<string> Instagrams { get; set; }
        public List<string> Outros { get; set; }
    }
}
