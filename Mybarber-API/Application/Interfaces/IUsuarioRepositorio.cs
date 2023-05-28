using Aplicacao.ObjetosDeTransferencia;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IUsuarioRepositorio
    {
        public Task<UsuarioObtidoPorEmail> ObterUsuarioPorEmail(string email);
    }
}
