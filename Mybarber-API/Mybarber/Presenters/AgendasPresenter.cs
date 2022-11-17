using AutoMapper;
using Mybarber.DataTransferObject.Agenda;

using Mybarber.Exceptions;
using Mybarber.Models;
using Mybarber.Presenters.Interfaces;
using Mybarber.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
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
                PropertyInfo[] properties = typeof(AgendasRequestDto).GetProperties();
                foreach(var atributo in properties)
                {
                    if(!(atributo.Name == "BarbeirosId" || atributo.Name == "BarbeariasId"))
                    {
                        List<float> valor = (List<float>)atributo.GetValue(agendasDto);
                        if(valor.Count <= 1)
                        {
                            throw new Exception("Cada dia precisa ter ao menos um horário de entrada e um horário de saída");
                        }
                        if(valor.Count > 2)
                        {
                            throw new Exception("Cada dia só pode ter um horário de entrada e um horário de saída");
                        }
                    }
                }
                var agenda = _mapper.Map<Agendas>(agendasDto);

                await _service.PostAgendaAsync(agenda);




                return agendasDto;

            }
            catch (Exception ex)
            {
                throw new ViewException("Operation.Failed: " + ex.Message, ex.Message);
            }
        }


        public async Task<List<float>> GerarHorariosAgedamentos(Guid idBarbeiro, DateTime data, string dia, Guid idServico, Guid tenant)
        {

            var result = await _service.PopularHorario(idBarbeiro, dia, data, tenant, idServico);


            return result;


        }



    }
}
