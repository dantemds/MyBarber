using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Relacionamento;
using Mybarber.Presenters.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/rolesusers")]
    public class RolesUsersControllers : ControllerBase
    {
        private readonly IRolesUsersPresenter _presenter;
        public RolesUsersControllers(IRolesUsersPresenter presenter)
        {
            this._presenter = presenter;
        }
        [HttpPost]
        public async Task<IActionResult> PostRelacionamentoAsync(UsersRolesRequestDto relacionamentoDto)
        {
            try
            {
                var result = await _presenter.PostRelacionamentoAsync(relacionamentoDto);
                return Created($"/api/v1/rolesusers/", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

    }
}
