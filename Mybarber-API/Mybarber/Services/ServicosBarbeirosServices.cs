using Mybarber.Models;
using Mybarber.Repositories;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class ServicosBarbeirosServices : IServicosBarbeirosServices
    {

        

        private readonly IGenerallyRepository _generally;

        public ServicosBarbeirosServices( IGenerallyRepository generally)
        {
            this._generally = generally;
          
        }

        public async Task<ServicosBarbeiros> PostServicoBarbeirosAsync(ServicosBarbeiros servicosBarbeiros)
        {
            _generally.Add(servicosBarbeiros);

            if (await _generally.SaveChangesAsync())
            {

                return servicosBarbeiros;
            }
            else
            {
                throw new InvalidOperationException("Operação falhou");
            }


        }

        public async Task<ServicosBarbeiros> PostServicoBarbeirosAsyncFromBarbeiro(ICollection<int> servicosId, Barbeiros barbeiro)
        {
            try
            {
                foreach (int i in servicosId)
                {
                     ServicosBarbeiros servicosBarbeiros = new ServicosBarbeiros(i, barbeiro.IdBarbeiro, barbeiro.BarbeariasId);

                   _generally.Add(servicosBarbeiros);

                    if (await _generally.SaveChangesAsync())
                    {

                       continue;
                        
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }catch(Exception)
            {
                throw new Exception();

            }

            return null;
            


        }
    }
}
