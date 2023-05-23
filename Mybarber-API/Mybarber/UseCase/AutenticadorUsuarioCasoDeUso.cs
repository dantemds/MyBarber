using Mybarber.Helpers;

namespace Mybarber.UseCase
{
    public class AutenticadorUsuarioCasoDeUso : IAutenticadorUsuarioCasoDeUso
    {
        private readonly IHash _hash;
        public AutenticadorUsuarioCasoDeUso(IHash hash)
        {
            this._hash = hash;
        }
        public bool AutenticaUsuario(string senha, string entrada)
        {
            return true;
        }
    }
}
