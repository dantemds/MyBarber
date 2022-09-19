using Microsoft.AspNetCore.Http;
using System;

namespace Mybarber.DataTransferObject.Banner
{
    public class BannerRequestDto
    {
        public IFormFile File { get; set; }
        public string Route { get; set; }
        public Guid BarbeariaId { get; set; }
        public string NomeImagem { get; set; }
    }
}
