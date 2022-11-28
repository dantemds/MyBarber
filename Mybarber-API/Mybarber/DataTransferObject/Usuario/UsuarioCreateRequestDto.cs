using System;

namespace Mybarber.DataTransferObject.Usuario
{
    public class UsuarioCreateRequestDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid BarbeariasId { get; set; }

    }
}
