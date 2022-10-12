using Microsoft.AspNetCore.Http;
using System;

namespace Mybarber.DataTransferObject.BarbeiroImagem
{
    public class BarbeiroImagemRequestS3Dto
    {
       public IFormFile File { get; set; }  
       public string Route { get; set; }
       public Guid IdBarbeiro { get; set; }
       public string NomeBarbeiro { get; set; }
    }
}
