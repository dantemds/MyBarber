using Microsoft.AspNetCore.Http;
using System;

namespace Mybarber.DataTransferObject.ServicoImagem
{
    public class ServicoImagemRequestS3Dto
    {

        public IFormFile File { get; set; }
        public string Route { get; set; }
        public Guid IdServico { get; set; }
        public string NomeImagem { get; set; }
    }
}
