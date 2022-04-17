

using Mybarber.DataTransferObject.Agenda;
using Mybarber.DataTransferObject.Images;
using Mybarber.Models;

namespace Mybarber.DataTransferObject.Barbeiro
{
    public class BarbeirosResponseDto 
    {
        public int IdBarbeiro { get; set; }
        public string NameBarbeiro { get; set; }
        public virtual BarbeiroImagemResponseDto BarbeiroImagem { get; set; }
        public virtual AgendasResponseDto Agendas { get; set; }

    }
}
