namespace Mybarber.Helpers
{
    public interface IHash
    {
        string CriptografarSenha(string senha);
        bool VerificarSenha(string senhaDigitada, string senhaCadastrada);
    }
}
