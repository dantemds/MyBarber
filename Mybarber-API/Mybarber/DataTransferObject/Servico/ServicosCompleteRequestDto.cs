using Microsoft.AspNetCore.Http;
using System;

namespace Mybarber.DataTransferObject.Servico
{
    public class ServicosCompleteRequestDto
    {
        public string NomeServico { get; set; }
        public DateTime TempoServico { get; set; }
        public float PrecoServico { get; set; }
        public Guid BarbeariasId { get; set; }
        public IFormFile File { get; set; }
        public string Route { get; set; }
    }
}
