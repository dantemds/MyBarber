using AutoMapper;
using Mybarber.DataTransferObject.Agendamento;
using Mybarber.Exceptions;
using Mybarber.Models;
using Mybarber.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenter
{
    public class AgendamentosPresenter : IAgendamentosPresenter
    {
        private readonly IMapper _mapper;
        private readonly IAgendamentosServices _service;
        public AgendamentosPresenter(IAgendamentosServices service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }


        public async Task<IEnumerable<AgendamentosResponseDto>> GetAllAgendamentosAsync()
        {
            try
            {
                var agendamento = await _service.GetAllAgendamentosAsync();

                return _mapper.Map<IEnumerable<AgendamentosResponseDto>>(agendamento);

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<AgendamentosResponseDto> GetAgendamentoAsyncById(int idAgendamento)
        {
            try
            {
                var agendamento = await _service.GetAgendamentoAsyncById(idAgendamento);

                return _mapper.Map<AgendamentosResponseDto>(agendamento);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    
        public async Task<AgendamentosCompleteResponseDto> PostAgendamentoAsync(AgendamentosRequestDto agendamentoDto)
        {
            try
            {
                if (agendamentoDto == null)
                    throw new ViewException("Agendamento.Missing.Info");
                if (string.IsNullOrEmpty(agendamentoDto.Email))
                    throw new ViewException("Email.Missing.Info");
                if (string.IsNullOrEmpty(agendamentoDto.Contato))
                    throw new ViewException("Contato.Missing.Info");
                if (string.IsNullOrEmpty(agendamentoDto.Name))
                    throw new ViewException("Name.Missing.Info");
                if (agendamentoDto.Horario.Equals(null))
                    throw new ViewException("Horario.Missing.Info");
                if (agendamentoDto.BarbeariasId.Equals(null))
                    throw new ViewException("Barbearia.Missing.Info");
                if (agendamentoDto.BarbeirosId.Equals(null))
                    throw new ViewException("Barbeiro.Missing.Info");
                if (agendamentoDto.ServicosId.Equals(null))
                    throw new ViewException("Servico.Missing.Info");


                var agendamento = _mapper.Map<Agendamentos>(agendamentoDto);

                await _service.PostAgendamentoAsync(agendamento);

                var b = await _service.GetAgendamentoAsyncById(agendamento.IdAgendamento);

                if (b == null)
                    throw new ViewException("Operation.Failed");

                return _mapper.Map<AgendamentosCompleteResponseDto>(b);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAgendamentoAsyncById(int idAgendamento)
        {


          await  _service.DeleteAgendamentoAsync(idAgendamento);

                return true;

        }
       
    }
}
