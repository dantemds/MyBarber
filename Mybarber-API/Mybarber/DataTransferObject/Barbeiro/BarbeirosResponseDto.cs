

using Mybarber.DataTransferObject.Agenda;
using Mybarber.DataTransferObject.Images;
using Mybarber.Models;
using System;

namespace Mybarber.DataTransferObject.Barbeiro
{
    public class BarbeirosResponseDto 
    {
        public Guid IdBarbeiro { get; set; }
        public Guid UsersId { get; set; }
        public string NameBarbeiro { get; set; }
        public  BarbeiroImagemResponseDto BarbeiroImagem { get; set; }
        public  AgendasResponseDto Agendas { get; set; }
        

    }
}
