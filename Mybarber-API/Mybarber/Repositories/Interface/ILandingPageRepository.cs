using Mybarber.Models;
using System;
using System.Threading.Tasks;

namespace Mybarber.Repositories.Interface
{
    public interface ILandingPageRepository
    {
        Task<LandingPageImages> GetImagemLadingById(Guid idLading);
    }
}
