using Microsoft.AspNetCore.Http;
using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IBarbeiroImagemServices
    {

        Task<BarbeiroImagens> PostBarbeiroImagemAsync(BarbeiroImagens imagem);
        Task<bool> PostBarbeiroImagemS3Async(IFormFile file,  string route, Guid idBarbeiro, string nomeBarbeiro);
        Task<bool> PutBarbeiroImagemS3Async(IFormFile file, string route, Guid idBarbeiro, string nomeBarbeiro);
        Task<bool> DeleteBarbeiroImagemS3Async(string route, Guid idBarbeiro);
    }
}
