
using Mybarber.Validations;

namespace Mybarber.DataTransferObject.Barbearia
{
    public class BarbeariasRequestDto 
    {


        public string NomeBarbearia { get; set; }

        public string CNPJ { get; set; }
        public string Route { get; set; }
        public bool LandingPage { get; set; }
        public bool Ativa { get; set; } = true;

        public BarbeariasRequestDto(string CNPJ, string nomeBarbearia, string route, bool landingPage)
        {
            this.NomeBarbearia = nomeBarbearia;
            this.CNPJ = Format.SemFormatacao(CNPJ);
            this.Route = route;
            this.LandingPage = landingPage;
            this.Ativa = true;
        }



    }
}
