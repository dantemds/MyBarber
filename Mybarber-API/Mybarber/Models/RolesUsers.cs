using System;

namespace Mybarber.Models
{
    public class RolesUsers
    {
        public Guid RolesId { get; set; }
        public Guid UsersId { get; set; }
        public Guid BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }
        public RolesUsers()
        {

        }
    }
}
