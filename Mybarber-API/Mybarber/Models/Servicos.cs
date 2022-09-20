﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class Servicos
    {

       
        [Key()]
        public Guid IdServico{ get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O nome deve ser informado")]
        public string NomeServico { get; set; }

        [Required(ErrorMessage = "O tempo deve ser informado")]
        public DateTime TempoServico { get; set; } 

        [Required(ErrorMessage = "O preço deve ser informado")]
        public float PrecoServico { get; set; }
        [ForeignKey("ServicoImagemId")]
        public Guid ServicoImagemId { get; set; }
        public virtual ServicoImagens ServicoImagem { get; set; } 

        public virtual ICollection<ServicosBarbeiros> ServicosBarbeiros { get; set; }
        [ForeignKey("Barbearias")]
        public Guid BarbeariasId { get; set; }

        public virtual Barbearias Barbearias { get; set; }

        public Servicos() 
        {
            
            ServicosBarbeiros = new HashSet<ServicosBarbeiros>();
        }





    }
}
