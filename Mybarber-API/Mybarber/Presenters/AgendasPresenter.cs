﻿using AutoMapper;
using Mybarber.DataTransferObject.Agenda;

using Mybarber.Exceptions;
using Mybarber.Models;
using Mybarber.Presenters.Interfaces;
using Mybarber.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public class AgendasPresenter : IAgendasPresenter
    {

        private readonly IMapper _mapper;
        private readonly IAgendasServices _service;

        public AgendasPresenter(IAgendasServices service, IMapper mapper
     )
        {
            this._service = service;
            this._mapper = mapper;

        }

        public async Task<AgendasRequestDto> PostAgendaAsync(AgendasRequestDto agendasDto)
        {
            try
            {
               

                var agenda = _mapper.Map<Agendas>(agendasDto);

                await _service.PostAgendaAsync(agenda);




                return agendasDto;

            }
            catch (Exception ex)
            {
                throw new ViewException("Operation.Failed", ex.Message);
            }
        }


        public async Task<List<float>> GerarHorariosAgedamentos(int idBarbeiro, DateTime data, string dia, int idServico, int tenant)
        {

            var result = await _service.PopularHorario( idBarbeiro,  dia,data,  idServico,  tenant);


            return result;


        }
       


    }
}
