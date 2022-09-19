using System;

namespace Mybarber.DataTransferObject.Enderecos
{
    public class EnderecosRequestDto
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public Guid BarbeariasId { get; set; }
    }
}
