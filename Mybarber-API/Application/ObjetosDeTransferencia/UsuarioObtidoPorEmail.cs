﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.ObjetosDeTransferencia
{
    public class UsuarioObtidoPorEmail
    {
        public Guid IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public UsuarioObtidoPorEmail(Guid id, string nomeUsuario, string email, string senha)
        {
            this.IdUsuario = id;
            this.NomeUsuario = nomeUsuario;
            this.Email = email;
            this.Senha = senha;
        }
    }
}