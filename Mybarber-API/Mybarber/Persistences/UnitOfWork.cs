using Microsoft.EntityFrameworkCore.Storage;
using Mybarber.Persistencia;
using System.Threading.Tasks;

namespace Mybarber.Persistences
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(Context context)
        {
            this._context = context;
        }
        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
           await _transaction.CommitAsync();
        }

        public void Dispose()
        {
           _transaction?.Dispose();
        }

        public async Task RollBack()
        {
            await _transaction.RollbackAsync();
        }
    }
}
