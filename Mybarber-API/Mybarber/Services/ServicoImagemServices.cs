using Mybarber.Models;
using Mybarber.Repository;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class ServicoImagemServices : IServicoImagemServices
    {
        private readonly IGenerallyRepository _generally;

        public ServicoImagemServices( IGenerallyRepository generally)
        {
          
            this._generally = generally;
        }

        public async Task<ServicoImagens> PostServicoImagemAsync(ServicoImagens imagem)
        {
            try
            {
                _generally.Add(imagem);

                if (await _generally.SaveChangesAsync())
                {

                    return imagem;
                }
                else
                {
                    throw new InvalidOperationException("Operação falhou");
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
