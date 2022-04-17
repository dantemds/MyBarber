using Microsoft.AspNetCore.Identity;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.Exceptions;
using Mybarber.Models;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class BarbeiroUsuarioServices : IBarbeiroUsuarioServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUsersServices _usersServices;

        public BarbeiroUsuarioServices(UserManager<IdentityUser> userManager, IUsersServices usersServices)
        {
            this._userManager = userManager;
            this._usersServices = usersServices;
        }

        public async Task<bool> CreateUsuarioBarbeiro(BarbeirosRequestDto barbeiroDto) 
        {
            try
            {
               

                var usuario = new IdentityUser
                {
                    UserName = barbeiroDto.NameBarbeiro,
                    Email = barbeiroDto.Email,
                    EmailConfirmed = true

                };

               IdentityUser duplicated =  await _userManager.FindByEmailAsync(usuario.Email);
                if (duplicated != null)
                      throw new ViewException("Operation.Failed");

              
               

             
                var identity = await _userManager.CreateAsync(usuario, barbeiroDto.Password);


                if (identity.Succeeded )
                {
                    return true;
                }
                else
                    throw new ViewException("Create.User.Failed");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUsuarioBarbeiro(Task<Barbeiros> barbeiro) 
        {

            var userBarbeiroFinded = await _userManager.FindByEmailAsync(barbeiro.Result.Email);


         var result =  await  _userManager.DeleteAsync(userBarbeiroFinded);

            if (!result.Succeeded)
            { throw new ViewException("Fail.Operation"); }
            else { return true; }



        }
    }
}
