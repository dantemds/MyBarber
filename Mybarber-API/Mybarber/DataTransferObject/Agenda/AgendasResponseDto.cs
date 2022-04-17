using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Agenda
{
    public class AgendasResponseDto
    {

        public int IdAgendas { get; set; }
        public List<float> Segunda { get; set; }

        public List<float> Terca { get; set; }

        public List<float> Quarta { get; set; }

        public List<float> Quinta { get; set; }

        public List<float> Sexta { get; set; }

        public List<float> Sabado { get; set; }

        public List<float> Domingo { get; set; }

        public int BarbeirosId { get; set; }
    }
}
