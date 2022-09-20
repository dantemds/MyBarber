using System;

namespace Mybarber.DataTransferObject.Relacionamento
{
    public class UsersRolesRequestDto
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public Guid BarbeariasId { get; set; }
    }
}
