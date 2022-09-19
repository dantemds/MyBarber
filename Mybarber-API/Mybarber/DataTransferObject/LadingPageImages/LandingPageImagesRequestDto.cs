using Microsoft.AspNetCore.Http;
using System;

namespace Mybarber.DataTransferObject.LadingPageImages
{
    public class LandingPageImagesRequestDto
    {
        public IFormFile File { get; set; }
        public string Route { get; set; }
        public Guid BarbeariaId { get; set; }
        public string NomeImagem { get; set; }
        public string Posicao { get; set; }
        public string Especificacao { get; set; }
    }
}
