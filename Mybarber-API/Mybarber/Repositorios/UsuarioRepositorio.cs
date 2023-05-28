using Aplicacao.Interfaces;
using Aplicacao.ObjetosDeTransferencia;
using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Context _contexto;

        public UsuarioRepositorio(Context context)
        {
            _contexto = context;
        }

        public async Task<UsuarioObtidoPorEmail> ObterUsuarioPorEmail(string email)
        {
            IQueryable<Users> query = _contexto.Users;
            query = query.AsNoTracking()
                    .OrderBy(users => users.IdUser)
                    .Where(users => users.Email == email);
            Users? usuarios = await query.FirstOrDefaultAsync()!;
            UsuarioObtidoPorEmail usuario = new UsuarioObtidoPorEmail(usuarios!.IdUser, usuarios.UserName, usuarios.Email, usuarios.Password);
            return usuario;
        }
    }
}
