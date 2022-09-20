using System;
using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Agenda
{
    public class AgendasResponseDto
    {

        public Guid IdAgendas { get; set; }
        public List<float> Segunda { get; set; }

        public List<float> Terca { get; set; }

        public List<float> Quarta { get; set; }

        public List<float> Quinta { get; set; }

        public List<float> Sexta { get; set; }

        public List<float> Sabado { get; set; }

        public List<float> Domingo { get; set; }

        public Guid BarbeirosId { get; set; }
    }
}
