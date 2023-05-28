using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Comandos
{
    public class ComandoAutenticarUsuario
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public ComandoAutenticarUsuario(string email, string senha)
        {
            this.Senha = senha;
            this.Email = email;
        }
    }
}
