

using System;

namespace Mybarber.DataTransferObject.Barbearia
{
    public class BarbeariasCompleteResponseDto
    {
        public Guid IdBarbearia { get; set; }

        public string NomeBarbearia { get; set; }

        public string CNPJ { get; set; }
        public string Route { get; set; }
        public bool FuncaoAgendamento { get; set; }
        public bool Ativa { get; set; }
    }
}
