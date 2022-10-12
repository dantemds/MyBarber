
using Mybarber.Validations;

namespace Mybarber.DataTransferObject.Barbearia
{
    public class BarbeariasRequestDto 
    {


        public string NomeBarbearia { get; set; }

        public string CNPJ { get; set; }
        public string Route { get; set; }
        public bool FuncaoAgendamento { get; set; }
        public bool Ativa { get; set; } = true;

        public BarbeariasRequestDto(string CNPJ, string nomeBarbearia, string route, bool FuncaoAgendamento)
        {
            this.NomeBarbearia = nomeBarbearia;
            this.CNPJ = Format.SemFormatacao(CNPJ);
            this.Route = route;
            this.FuncaoAgendamento = FuncaoAgendamento;
            this.Ativa = true;
        }



    }
}
