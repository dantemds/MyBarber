using System;

namespace Mybarber.DataTransferObject.Temas
{
    public class TemasRequestDto
    {
        public string CorPrimaria { get; set; }
        public string CorSecundaria { get; set; }
        public string CorTernaria { get; set; }
        public string CorQuartenaria { get; set; }
        public Guid BarbeariasId { get; set; }
    }
}
