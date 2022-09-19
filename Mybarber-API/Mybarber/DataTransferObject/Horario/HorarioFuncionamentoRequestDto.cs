using System;
using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Horario
{
    public class HorarioFuncionamentoRequestDto
    {
        public List<string> Funcionamento { get; set; }
        public Guid BarbeariasId { get; set; }
    }
}
