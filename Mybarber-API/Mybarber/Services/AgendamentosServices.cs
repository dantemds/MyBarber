﻿using Microsoft.Extensions.Configuration;
using Mybarber.Exceptions;
using Mybarber.Exceptions.Tradutor;
using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Models.Enum;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using Mybarber.Validations;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Mybarber.Exceptions.BusinessException;

namespace Mybarber.Services
{
    public class AgendamentosServices : IAgendamentosServices
    {
        private readonly IAgendamentosRepository _repo;
        private readonly ISMSService _sms;

        private readonly IGenerallyRepository _generally;
        private readonly IEmailServices _email;
        private readonly IBarbeirosRepository _barbeirosRepository;

        public AgendamentosServices(IAgendamentosRepository repo, IGenerallyRepository generally, IEmailServices email, ISMSService sms, IBarbeirosRepository barbeirosRepository)
        {
            this._repo = repo;
            this._generally = generally;
            this._sms = sms;
            this._email = email;
            this._barbeirosRepository = barbeirosRepository;
        }

        public async Task<IEnumerable<Agendamentos>> GetAllAgendamentosAsync()
        {
            try
            {
                var agendamentos = await _repo.GetAllAgendamentosAsync();

                return agendamentos;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Agendamentos> GetAgendamentoAsyncById(int idAgendamento)
        {
            try
            {
                var agendamento = await _repo.GetAgendamentosAsyncById(idAgendamento);

                return agendamento;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Agendamentos> PostAgendamentoAsync(Agendamentos agendamentos)
        {
            try
            {
                

                if (ValidaEmail.IsEmail(agendamentos.Email) == false)
                    throw new EmailException(TraslateExceptions.EmailInvalido);
                var horario = await _repo.GetAgendamentosAsyncByHorario(agendamentos);
                if (horario != null)
                    throw new AgendamentoException(TraslateExceptions.AgendamentoConflituoso);
                //if ((DateTime.Compare(agendamentos.Horario, DateTime.Now)<0))
                //    throw new AgendamentoException(TraslateExceptions.AgendamentoImpossivel);

                var barbeiro = await _barbeirosRepository.GetBarbeirosAsyncById(agendamentos.BarbeirosId);
                

                _generally.Add(agendamentos);

               
                

                if (await _generally.SaveChangesAsync())

                {
                    try
                    {
                        //_email.SendEmail(agendamentos, "EmailAgendamento");
                        _email.SendSESEMail(agendamentos, "EmailAgendamento");
                        _sms.SendSMS(agendamentos.Contato, MensagemSMS.BuscaMensagem(MensagemSMS.TipoMensagem.AgendamentoCliente, agendamentos));
                        if (barbeiro.BarbeiroContato != null)
                        {
                            _sms.SendSMS(barbeiro.BarbeiroContato, MensagemSMS.BuscaMensagem(MensagemSMS.TipoMensagem.AgendamentoBarbeiro, agendamentos));
                        }
                    }
                    catch(Exception ex)
                    { return agendamentos; }
                    return agendamentos;

                }
                else
                {
                    throw new ViewException("Operação falhou");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteAgendamentoAsync(int idAgendamento) 
        {
            var agendamento = await _repo.GetAgendamentosAsyncById(idAgendamento);
            if (agendamento.Equals(null))
                throw new ViewException("Agendamento.Is.Not.Present");

            _generally.Delete(agendamento);

            if (await _generally.SaveChangesAsync()) 
            {
                //_email.SendEmail(agendamento, "EmailCancelamento");
                _email.SendSESEMail(agendamento, "EmailCancelamento");
                _sms.SendSMS(agendamento.Contato, MensagemSMS.BuscaMensagem(MensagemSMS.TipoMensagem.CancelarAgendamento, agendamento));
                Log.Information("Agendamento cancelado ", idAgendamento);
                return true;
            
            }
            else
            {
                throw new InvalidOperationException("Operação falhou");
            }
        }

    }
}
