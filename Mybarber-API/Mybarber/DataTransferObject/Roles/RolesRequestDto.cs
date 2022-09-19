using System;

namespace Mybarber.DataTransferObject.Roles
{
    public class RolesRequestDto
    {
        public Guid IdRole { get; set; }
        public string RoleName { get; set; }
        public Guid RoleStrength { get; set; }
    }
}
