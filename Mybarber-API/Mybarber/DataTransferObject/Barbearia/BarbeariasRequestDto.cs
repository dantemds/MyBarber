
using Mybarber.Validations;

namespace Mybarber.DataTransferObject.Barbearia
{
    public class BarbeariasRequestDto 
    {


        public string NomeBarbearia { get; set; }

        public string CNPJ { get; set; }

        public BarbeariasRequestDto(string CNPJ, string nomeBarbearia)
        {
            this.NomeBarbearia = nomeBarbearia;
            this.CNPJ = Format.SemFormatacao(CNPJ);
        }



    }
}
