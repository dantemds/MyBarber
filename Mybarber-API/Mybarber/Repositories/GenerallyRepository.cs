using Mybarber.Persistencia;
using Mybarber.Repository;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class GenerallyRepository : IGenerallyRepository
    {
        private readonly Context _context;

        public GenerallyRepository(Context context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
