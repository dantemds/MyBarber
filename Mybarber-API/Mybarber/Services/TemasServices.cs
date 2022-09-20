using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class TemasServices: ITemasServices
    {

        private readonly IGenerallyRepository _generally;
        public TemasServices(IGenerallyRepository generally)
        {

        }

        public async Task<Temas> PostTemaAsync(Temas tema)
        {

            _generally.Add(tema);
            if (await _generally.SaveChangesAsync())
            {
                return tema;
            }
            else
            {
                throw new Exception();
            }


        }
    }
}
