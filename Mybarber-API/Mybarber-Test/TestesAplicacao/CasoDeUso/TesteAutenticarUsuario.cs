using Aplicacao.CasosDeUso.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test.TestesAplicacao
{
    public class TesteAutenticarUsuario
    {
        private readonly IAutenticarUsuario _autenticarUsuario;
        public TesteAutenticarUsuario(IAutenticarUsuario autenticarUsuario)
        {
            this._autenticarUsuario = autenticarUsuario;
        }
        public void Deve_Autenticar_Usuario()
        {

        }
    }
}
