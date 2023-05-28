using Aplicacao.CasosDeUso.Interfaces;
using Aplicacao.Comandos;
using Aplicacao.Interfaces;
using Aplicacao.ObjetosDeTransferencia;
using Dominio;


namespace Aplicacao.CasosDeUso
{
    public class AutenticarUsuario: IAutenticarUsuario
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IHash _hash;
        public AutenticarUsuario(IUsuarioRepositorio usuarioRepositorio, IHash hash)
        {
            this._usuarioRepositorio = usuarioRepositorio;
            this._hash = hash;
        }
        public async Task<UsuarioAutenticado> Executar(ComandoAutenticarUsuario comando)
        {
            UsuarioObtidoPorEmail usuarioEncontrado = await _usuarioRepositorio.ObterUsuarioPorEmail(comando.Email);
            return new UsuarioAutenticado(new Guid(), new Guid(), "A", "A", new Guid());
        }
    }
}
