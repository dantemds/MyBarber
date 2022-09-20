using Microsoft.AspNetCore.Http;
using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IServicoImagemServices
    {
        Task<ServicoImagens> PostServicoImagemAsync(ServicoImagens imagem);
        Task<ServicoImagens> PostServicoImagemS3Async(IFormFile file, string route, Guid idServico, string nomeServico);
        Task<bool> PutServicoImagemS3Async(IFormFile file, string route, Guid idServico, string nomeServico);
        Task<bool> DeleteServicoImagemS3Async(string route, Guid idServico);
    }
}
