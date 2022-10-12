using Microsoft.AspNetCore.Http;
using Mybarber.DataTransferObject.BarbeiroImagem;
using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IBarbeiroImagemServices
    {

        Task<BarbeiroImagens> PostBarbeiroImagemAsync(BarbeiroImagens imagem);
        Task<bool> PostBarbeiroImagemS3Async(BarbeiroImagemRequestS3Dto dto);
        Task<bool> PutBarbeiroImagemS3Async(IFormFile file, string route, Guid idBarbeiro, string nomeBarbeiro);
        Task<bool> DeleteBarbeiroImagemS3Async(string route, Guid idBarbeiro);
    }
}
