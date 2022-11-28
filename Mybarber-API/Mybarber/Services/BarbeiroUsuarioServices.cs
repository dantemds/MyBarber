using Microsoft.AspNetCore.Identity;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.Exceptions;
using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Repositories;
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
        private readonly IUsersRepository _usersRepository;
        public BarbeiroUsuarioServices(IGenerallyRepository generally, UserManager<IdentityUser> userManager, IUsersServices usersServices, IHash hash, IUsersRepository usersRepository)
        {
            this._generally = generally;
            this._hash = hash;  
            this._usersServices = usersServices;
            this._usersRepository = usersRepository;
        }

        public async Task<Users> CreateUsuarioBarbeiro(BarbeirosRequestDto barbeiroDto) 
        {
            try
            {

                var usuarioFinded = await _usersRepository.GetUserAsyncByEmail(barbeiroDto.Email);
                if (usuarioFinded !=  null) throw new Exception();
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
                    return usuario;
                else throw new Exception();





            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<bool> DeleteUsuarioBarbeiro(Barbeiros barbeiros)
        {
            try
            {
                _generally.Delete(barbeiros.Users);
                if (await _generally.SaveChangesAsync())
                    return true;
                else throw new Exception();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    }
}
