using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Repositories.Interface
{
    public interface IBarbeiroImagemRepository
    {
        Task<BarbeiroImagens> GetImagemBarbeiroByIdBarbeiro(Guid idBarbeiro);
    }
}
