
using Mybarber.Validations;

namespace Mybarber.DataTransferObject.Barbearia
{
    public class BarbeariasRequestDto 
    {


        public string NomeBarbearia { get; set; }

        public string CNPJ { get; set; }
        public string Route { get; set; }

        public BarbeariasRequestDto(string CNPJ, string nomeBarbearia, string route)
        {
            this.NomeBarbearia = nomeBarbearia;
            this.CNPJ = Format.SemFormatacao(CNPJ);
            this.Route = route;
        }



    }
}
