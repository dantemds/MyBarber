using System;
using System.Threading.Tasks;

namespace Mybarber.Persistences
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollBack();
    }
}
