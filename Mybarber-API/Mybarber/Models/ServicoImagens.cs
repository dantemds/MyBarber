﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mybarber.Models
{
    public class ServicoImagens
    {
        [Key()]
        public Guid IdImagemServico { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string URL { get; set; }

        public virtual ICollection<Servicos> Servicos { get; set; }

        public ServicoImagens() { }




    }
}
