﻿using System;

namespace Mybarber.DataTransferObject.Relacionamento
{
    public class UsersRolesRequestDto
    {
        public Guid RolesId { get; set; }
        public Guid UsersId { get; set; }
        public Guid BarbeariasId { get; set; }
    }
}
