
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mybarber.Exceptions;
using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Repositories;
using Mybarber.Repository;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Mybarber.Controllers
{
   
    [EnableCors]
    [ApiController]
    [Route("api/v1/aut")]
    public class AuthenticatorControllers : ControllerBase
    {
        private readonly IUsersRepository _Authenticate;
        private readonly IGenerallyRepository _generally;
        private readonly IUsersRepository _repoUser;
       
       

     
       
        private readonly AppSettings _appSettings;
   
        private readonly IHash _hash;



        public AuthenticatorControllers(IUsersRepository Authenticate,
            IGenerallyRepository generally, 
            UserManager<IdentityUser> userManager,
            IOptions<AppSettings> appSettings,  IBarbeirosRepository repoBarbeiro, IHash hash, IUsersRepository repoUser)
        {
            this._Authenticate = Authenticate;
            this._generally = generally;
            this._hash = hash;

            this._repoUser = repoUser;
            this._appSettings = appSettings.Value;
          
            


        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateAsync(Users model)
        {



          var user = await  _Authenticate.GetUserAsyncByEmail(model.Email);

            if (_hash.VerificarSenha(model.Password, user.Password) == true)
            {
                var token = await GerarJwt(model.Email);


                RetornoUsuario retorno = new RetornoUsuario(user.IdUser, user.UserName, token, user.BarbeariasId);

                return Ok(retorno);

            }
            else return BadRequest();




        





            //var user = await _Authenticate.GetUserAsync(model.Username, model.Password);
            //var roles = await _Aut.GetRoleAsyncByUsersId(user.IdUser);

            //if (user == null)
            //    return NotFound(new { messaage = "Usuário ou senha inválido" });

            //var token = TokenServices.GenerateToken(user);

            ////HttpContext.Session.SetString("SessionNome", user.Username);

            ////HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));



            //user.Password = "";
            //return new
            //{
            //    user = user.Username,
            //    token = token
            //};

        }
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult> PostUserAsync(Users user)
        {

            var passwordHash = _hash.CriptografarSenha(user.Password);


            var usuario = new Users
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = passwordHash,
                BarbeariasId = user.BarbeariasId
            };


         _generally.Add(usuario);
            if (await _generally.SaveChangesAsync())
                return Ok();
            else return BadRequest()
    ;





















            //try
            //{
            //    _generally.Add(user);

            //    if (await _generally.SaveChangesAsync())
            //    {
            //        return Ok();
            //    }
            //    else { return BadRequest(); }

            //}
            //catch (Exception)
            //{

            //    throw new Exception();
            //}


        }


        //[HttpPatch]
        //public async Task<ActionResult> PatchUserPasswordAsync( [FromBody] Users user)
        //{
        //    try
        //    {
                
              
                


        //        var identityFinded = await _userManager.FindByEmailAsync(user.Email);

        //        var senha = _userManager.PasswordHasher.HashPassword(identityFinded, user.Password);
        //        identityFinded.PasswordHash = senha;
        //        await _userManager.UpdateAsync(identityFinded);

               

               
               
                

               

        //        await _generally.SaveChangesAsync();
        //        return Ok(); 
               
        //    }
        //    catch (Exception ex)
        //    { throw new Exception(ex.Message); }

            
           

        //}






        private async Task<string> GerarJwt(string email)
        {



            var user = await _repoUser.GetUserAsyncByEmail(email);





       





            



            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)

            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }









        public class RetornoUsuario
        {
            public int IdBarbeiro { get; set; }
            public string NomeUsuario { get; set; }

            public string Token { get; set; }

            public int IdBarbearia { get ; set; }

            public RetornoUsuario(int idUser,string nomeUsuario, string token, int idbarbearia)
            {
                this.NomeUsuario = nomeUsuario;
                this.Token = token;
                this.IdBarbearia = idbarbearia;
                this.IdBarbeiro = idUser;
            }




        }

    }
}
