using System;

namespace Mybarber.DataTransferObject.Roles
{
    public class RolesResponseDto
    {
        public Guid IdRole { get; set; }
        public string Name { get; set; }
        public int LevelRole { get; set; }
    }
}
