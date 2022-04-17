using System.Threading.Tasks;

namespace Mybarber.Repository
{
    public interface IGenerallyRepository
    {

        //GENERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

    }
}
