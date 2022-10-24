using System;

namespace Mybarber.Models
{
    public class RolesUsers
    {
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        public Guid UsersId { get; set; }
        public Guid BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }
        public virtual Users Users { get; set; }

        public RolesUsers(Guid RolesId, Guid UsersId, Guid BarbeariasId)
        {
            this.RoleId = RolesId;
            this.UsersId = UsersId;
            this.BarbeariasId = BarbeariasId;
        }
        public RolesUsers()
        {

        }
    }
}
