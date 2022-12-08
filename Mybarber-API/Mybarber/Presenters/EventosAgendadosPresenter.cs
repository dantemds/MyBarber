using AutoMapper;
using Mybarber.DataTransferObject.EventoAgendado;
using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Presenters.Interfaces;
using Mybarber.Repositories.Interface;
using Mybarber.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public class EventosAgendadosPresenter: IEventosAgendadosPresenter
    {

        private readonly IMapper _mapper;
        private readonly IGenerallyRepository _repo;
        private readonly IAgendamentosRepository _agendamentosRepo;
        private readonly IEventoRepository _eventoRepo;
        public EventosAgendadosPresenter(IMapper mapper,IGenerallyRepository repo, IAgendamentosRepository agendamentosRepo, IEventoRepository eventoRepo)
        {
            this._mapper = mapper;
            this._repo = repo;
            this._agendamentosRepo = agendamentosRepo;
            this._eventoRepo = eventoRepo;
        }

        public async Task<bool> DeleteEventoAgendadoAsync(int idEvento)
        {
            var evento = await _eventoRepo.GetAgendamentosAsyncById(idEvento);
            _repo.Delete(evento);
            if (await _repo.SaveChangesAsync())
            {
                return true;
            }
            else
            {
                throw new Exception();
            }
        }
        private async Task<TimeSpan> ValidadeEvento(EventoAgendadoRequestDto dto)
        {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var horaI = dto.HoraInicio.Split(':');
            var horaDouble = Convert.ToInt32(horaI[0]);
            var minutosDouble = Convert.ToInt32(horaI[1]);
            var horaInicio = new DateTime(0001, 1, 1, horaDouble, minutosDouble, 0);

            var horaF = dto.HoraFim.Split(':');
            var horaFDouble = Convert.ToInt32(horaF[0]);
            var minutosFDouble = Convert.ToInt32(horaF[1]);
            var horaFim = new DateTime(0001, 1, 1, horaFDouble, minutosFDouble, 0);

            var duracao = horaFim - horaInicio;
            var eventos = await _eventoRepo.GetEventosByBarbeiroAsync(dto.BarbeirosId);
            foreach(var evento in eventos)
            {
                if(evento.DiaSemana == dto.DiaSemana)
                {
                    var eventoMarcadoInicio = evento.HoraInicio;
                    if (dto.HoraInicio.ToString() == eventoMarcadoInicio) throw new Exception("Evento Repetido");
                    var dtoHoraI = dto.HoraInicio.ToString().Replace("30", "5").Replace(":", ".");
                    var dtoHoraF = dto.HoraFim.ToString().Replace("30", "5").Replace(":", ".");
                    var dtoHoraIFloat = Convert.ToSingle(dtoHoraI);
                    var dtoHoraFFloat = Convert.ToSingle(dtoHoraF);
                    var agendaDto = new List<float>();

                    for (float i = dtoHoraIFloat; i < dtoHoraFFloat; i += 0.5f)
                    {
                        agendaDto.Add(i);
                    }
                    var agendaEventosDto = new List<float>();
                    var eventoMarcadoI = eventoMarcadoInicio.Replace("30", "5").Replace(":", ".");
                    var eventoIFloat = Convert.ToSingle(eventoMarcadoI);
                    var duracaoEvento = evento.Duracao.ToString().Substring(0,5);
                    duracaoEvento = duracaoEvento.Replace("30", "5").Replace(":", ".");
                    var eventoFFloat = eventoIFloat + Convert.ToSingle(duracaoEvento);
                    for (float i = eventoIFloat; i < eventoFFloat; i += 0.5f)
                    {
                        agendaEventosDto.Add(i);
                    }

                    foreach (float i in agendaEventosDto)
                    {
                        foreach (float j in agendaDto)
                        {
                            if (i == j)
                            {
                                throw new Exception("Evento Repetido");
                            }
                        }
                    }

                }
            }
            var agendamentos = await _agendamentosRepo.GetAgendamentosApartirDeByBarbeiro(DateTime.Now, dto.BarbeirosId);
            var agendamentosResult = new List<Agendamentos>();
            if (dto.Temporario)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                foreach (var agendamento in agendamentos)
                {
                    
                    var agendamentoHorario = agendamento.Horario.ToString("dd/MM/yyyy");
                    var dataFim = dto.DataFim;
                    var agendamentoConvert =Convert.ToDateTime(agendamentoHorario);
                    var dataFimConvert = Convert.ToDateTime(dataFim);
                    if(agendamentoConvert <= dataFimConvert)
                    {
                        agendamentosResult.Add(agendamento);

                    }
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            }
            else
            {
                agendamentosResult = (List<Agendamentos>) agendamentos.Clone();
            }
            
                foreach (var agendamento in agendamentosResult)
                {
                    string diaSemanaString = "dia";
                    var diaSemana = (int)agendamento.Horario.DayOfWeek;
                    //monday = 1..
                    switch (diaSemana)
                    {
                        case 1:
                            diaSemanaString = "segunda";

                            break;
                        case 2:

                            diaSemanaString = "terca";
                            break;
                        case 3:
                            diaSemanaString = "quarta";

                            break;
                        case 4:
                            diaSemanaString = "quinta";

                            break;
                        case 5:
                            diaSemanaString = "sexta";

                            break;
                        case 6:
                            diaSemanaString = "sabado";

                            break;
                        case 7:

                            diaSemanaString = "domingo";
                            break;
                    }

                    if (diaSemanaString == dto.DiaSemana)
                    {
                        string horaAgendamento = agendamento.Horario.ToString("HH:mm");
                        if (dto.HoraInicio.ToString() == horaAgendamento) throw new Exception("Canceles seus agendamentos");

                        var dtoHoraI = dto.HoraInicio.ToString().Replace("30", "5").Replace(":", ".");
                        var dtoHoraF = dto.HoraFim.ToString().Replace("30", "5").Replace(":", ".");
                        var dtoHoraIFloat = Convert.ToSingle(dtoHoraI);
                        var dtoHoraFFloat = Convert.ToSingle(dtoHoraF);
                        var agendaDto = new List<float>();

                        for (float i = dtoHoraIFloat; i < dtoHoraFFloat; i += 0.5f)
                        {
                            agendaDto.Add(i);
                        }
                        var agendaAgendamentoDto = new List<float>();
                        var agendamentoI = horaAgendamento.Replace("30", "5").Replace(":", ".");
                        var agendamentoIFloat = Convert.ToSingle(agendamentoI);
                        var duracaoAgendamento = agendamento.Servicos.TempoServico.ToString("HH:mm").Replace("30", "5").Replace(":", "."); ;
                        var agendamentoFFloat = agendamentoIFloat + Convert.ToSingle(duracaoAgendamento);
                        for (float i = agendamentoIFloat; i < agendamentoFFloat; i += 0.5f)
                        {
                            agendaAgendamentoDto.Add(i);
                        }

                        foreach (float i in agendaAgendamentoDto)
                        {
                            foreach (float j in agendaDto)
                            {
                                if (i == j)
                                {
                                    throw new Exception("Canceles seus agendamentos");
                                }
                            }
                        }

                    }
                }
            return duracao;
        }
        public async Task<EventoAgendadoRequestDto> PostEventoAgendadoAsync(EventoAgendadoRequestDto dto)
        {
            try
            {
                var duracao = await ValidadeEvento(dto);
                var eventoAgendado = _mapper.Map<EventoAgendado>(dto);
                eventoAgendado.Duracao = duracao;
                

                _repo.Add(eventoAgendado);
                
                if(await _repo.SaveChangesAsync())
                {
                    return dto;
                }
                else
                {
                    throw new Exception();
                }

                
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }

        public async Task<List<EventoAgendadoResponseDto>> GetEventosByBarbeiro(Guid idBarbeiro)
        {
            try
            {
                var result = await _eventoRepo.GetEventosByBarbeiroAsync(idBarbeiro);
                var retorno = new List<EventoAgendadoResponseDto>();
                foreach(var item in result)
                {
                    retorno.Add(_mapper.Map<EventoAgendadoResponseDto>(item));

                }
                return retorno;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoAgendadoResponseDto> UpdateEventoAgendadoAsync(EventoAgendadoRequestDto dto, int idEvento)
        {
            var duracao = await ValidadeEvento(dto);
            var evento = await _eventoRepo.GetAgendamentosAsyncById(idEvento);

            evento.DescricaoEvento = dto.DescricaoEvento;
            evento.NomeEvento = dto.NomeEvento;
            evento.BarbeariasId = dto.BarbeariasId;
            evento.Duracao = duracao;
            evento.BarbeirosId = dto.BarbeirosId;
            evento.DiaSemana = dto.DiaSemana;
            evento.HoraFim = dto.HoraFim;
            evento.HoraInicio = dto.HoraInicio;


            _repo.Update(evento);
            if (await _repo.SaveChangesAsync())
            {

                return _mapper.Map<EventoAgendadoResponseDto>(evento);
            }
            else
            {
                throw new Exception();
            }

        }
    }
}
