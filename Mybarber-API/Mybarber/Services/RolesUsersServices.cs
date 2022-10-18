using Microsoft.AspNetCore.Mvc;
using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class RolesUsersServices: IRolesUsersServices
    {

        private readonly IGenerallyRepository _generally;
        public RolesUsersServices(IGenerallyRepository generally)
        {
            this._generally = generally;
        }

        public async Task<RolesUsers> PostRelacionamentoAsync(RolesUsers  rolesUsers)
        {
            _generally.Add(rolesUsers);

            if (await _generally.SaveChangesAsync())
            {

                return rolesUsers;
            }
            else
            {
                throw new InvalidOperationException("Operação falhou");
            }
        }
    }
}
