using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class ContatosServices :IContatosServices
    {
        private readonly IGenerallyRepository _generally;
        public ContatosServices(IGenerallyRepository generally)
        {
            this._generally = generally;
        }

        public async Task<Contatos> PostContatosAsync(Contatos contato)
        {
            _generally.Add(contato);

            if (await _generally.SaveChangesAsync())
            {
                return contato;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
