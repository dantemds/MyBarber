using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Roles;
using Mybarber.Models;
using Mybarber.Repositories;
using Mybarber.Repositories.Interface;
using Mybarber.Repository;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/roles")]
    public class RolesControllers : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IGenerallyRepository _generally;
        private readonly IRolesRepository _repo;
        public RolesControllers(IMapper mapper, IGenerallyRepository generally, IRolesRepository repo)
        {
            this._mapper = mapper;
            this._generally = generally;
            this._repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
          var result =  await _repo.GetAllRolesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostRoleAsync(RolesRequestDto dto)
        {
            try
            {
                _generally.Add(_mapper.Map<Role>(dto));
                if (await _generally.SaveChangesAsync())
                {
                    return Created("api/v1/role/", dto);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
