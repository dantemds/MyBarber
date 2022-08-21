﻿using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Temas;
using Mybarber.Models;
using Mybarber.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/temas")]
    public class TemasControllers : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenerallyRepository _generally;
        public TemasControllers( IGenerallyRepository generally, IMapper mapper)
        {
            this._generally = generally;
            this._mapper = mapper;
        }

        [HttpPost()]
        public async Task<IActionResult> PostTemaAsync([FromBody] TemasRequestDto tema)
        {



            _generally.Add(_mapper.Map<Temas>(tema));

            if(await _generally.SaveChangesAsync())
            {
                return Ok(tema);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
