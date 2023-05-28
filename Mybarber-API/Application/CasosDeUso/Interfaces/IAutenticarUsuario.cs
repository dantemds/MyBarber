using Aplicacao.Comandos;
using Aplicacao.ObjetosDeTransferencia;
using Dominio;


namespace Aplicacao.CasosDeUso.Interfaces
{
    public interface IAutenticarUsuario
    {
        Task<UsuarioAutenticado> Executar(ComandoAutenticarUsuario comando);

    }
}
