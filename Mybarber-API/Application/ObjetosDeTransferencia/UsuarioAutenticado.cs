using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.ObjetosDeTransferencia
{
    public class UsuarioAutenticado
    {
        public Guid IdBarbeiro { get; set; }
        public Guid IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Token { get; set; }
        public Guid IdBarbearia { get; set; }

        public UsuarioAutenticado(Guid idBarbeiro, Guid idUsuario, string nomeUsuario, string token, Guid idBarbearia)
        {
            IdBarbeiro = idBarbeiro;
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            Token = token;
            IdBarbearia = idBarbearia;
        }
    }
}
