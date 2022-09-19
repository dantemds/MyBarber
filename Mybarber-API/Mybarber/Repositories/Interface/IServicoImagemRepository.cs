using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Repositories.Interface
{
    public interface IServicoImagemRepository
    {
        Task<ServicoImagens> GetImagemServicoByIdServico(Guid idServico);
    }
}
