using Microsoft.AspNetCore.Identity;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.Exceptions;
using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class BarbeiroUsuarioServices : IBarbeiroUsuarioServices
    {
        private readonly IHash _hash;
        private readonly IUsersServices _usersServices;
        private readonly IGenerallyRepository _generally;
        public BarbeiroUsuarioServices(IGenerallyRepository generally, UserManager<IdentityUser> userManager, IUsersServices usersServices, IHash hash)
        {
            this._generally = generally;
            this._hash = hash;
            this._usersServices = usersServices;
        }

        public async Task<bool> CreateUsuarioBarbeiro(BarbeirosRequestDto barbeiroDto) 
        {
            try
            {


                var passwordHash = _hash.CriptografarSenha(barbeiroDto.Password);


                var usuario = new Users
                {
                    UserName = barbeiroDto.NameBarbeiro,
                    Email = barbeiroDto.Email,
                    Password = passwordHash,

                    BarbeariasId = barbeiroDto.BarbeariasId
                };





                _generally.Add(usuario);
                if (await _generally.SaveChangesAsync())
                    return true;
                else throw new Exception();





            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

        public Task<bool> DeleteUsuarioBarbeiro()
        {
            throw new NotImplementedException();
        }
    }
}
