using Mybarber.DataTransferObject.Agenda;
using Mybarber.DataTransferObject.BarbeiroImagem;
using System;
using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Barbeiro
{
    public class BarbeirosCompleteRequestDto
    {
        public string Email { get; set; }
        public string NameBarbeiro { get; set; }
        public Guid BarbeariasId { get; set; }
        public string Password { get; set; }
        public BarbeiroImagemRequestS3Dto BarbeiroImagemRequestDto { get; set; }  
        public AgendasRequestDto AgendasRequestDto { get; set; }
        public ICollection<Guid> ServicosId { get; set; }


    }
}
