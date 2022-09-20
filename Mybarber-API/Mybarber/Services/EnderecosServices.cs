using Microsoft.AspNetCore.Mvc;
using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class EnderecosServices : IEnderecosServices
    {
        private readonly IGenerallyRepository _generally;
        public EnderecosServices(IGenerallyRepository generally)
        {
            this._generally = generally;
        }

        public async Task<Enderecos> PostEnderecoAsync(Enderecos endereco)
        {
            _generally.Add(endereco);

            if (await _generally.SaveChangesAsync())
            {
                return endereco;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
