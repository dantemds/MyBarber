using Microsoft.AspNetCore.Http;
using Mybarber.DataTransferObject.ServicoImagem;
using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IServicoImagemServices
    {
        Task<ServicoImagens> PostServicoImagemAsync(ServicoImagens imagem);
        Task<ServicoImagens> PostServicoImagemS3Async(ServicoImagemRequestS3Dto dto);
        Task<bool> PutServicoImagemS3Async(ServicoImagemRequestS3Dto dto);
        Task<bool> DeleteServicoImagemS3Async(string route, Guid idServico);
    }
}
