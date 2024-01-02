using Microsoft.Extensions.Configuration;
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
                {
                    Console.WriteLine(TraslateExceptions.AgendamentoConflituoso);
                    throw new AgendamentoException(TraslateExceptions.AgendamentoConflituoso);
                }
                //if ((DateTime.Compare(agendamentos.Horario, DateTime.Now)<0))
                //    throw new AgendamentoException(TraslateExceptions.AgendamentoImpossivel);

                var barbeiro = await _barbeirosRepository.GetBarbeirosAsyncById(agendamentos.BarbeirosId);


                _generally.Add(agendamentos);




                if (await _generally.SaveChangesAsync())

                {
                    try
                    {
                        try
                        {

                            try
                            {
                                _email.SendSESEMail(agendamentos, "EmailAgendamentoBarbeiro", barbeiro.Users.Email);
                                _email.SendSESEMail(agendamentos, "EmailAgendamento");

                            }
                            catch (Exception ex)
                            {
                                _email.SendSESEMail(agendamentos, "EmailAgendamento");
                            }
                        }
                        catch (Exception ex)
                        {
                            //if (agendamentos.BarbeariasId.ToString() == "1956aa91-5157-48a8-a505-7fc40129c5b1" || agendamentos.BarbeariasId.ToString() == "22bb9a51-bd65-4556-8681-ecd5093e9042")
                            //{
                            //    _sms.SendSMS(agendamentos.Contato, MensagemSMS.BuscaMensagem(MensagemSMS.TipoMensagem.AgendamentoCliente, agendamentos));
                            //    if (barbeiro.BarbeiroContato != null)
                            //    {
                            //        _sms.SendSMS(barbeiro.BarbeiroContato, MensagemSMS.BuscaMensagem(MensagemSMS.TipoMensagem.AgendamentoBarbeiro, agendamentos));
                            //    }
                            //}
                            return agendamentos;
                        }
                        //if (agendamentos.BarbeariasId.ToString() == "1956aa91-5157-48a8-a505-7fc40129c5b1" || agendamentos.BarbeariasId.ToString() == "22bb9a51-bd65-4556-8681-ecd5093e9042")
                        //{
                        //    if (barbeiro.BarbeiroContato != null)
                        //    {
                        //        _sms.SendSMS(barbeiro.BarbeiroContato, MensagemSMS.BuscaMensagem(MensagemSMS.TipoMensagem.AgendamentoBarbeiro, agendamentos));
                        //    }
                        //}

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return agendamentos;
                    }
                    return agendamentos;
                }
                else
                {
                    throw new ViewException("Operação falhou");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                try
                {
                    _email.SendSESEMail(agendamento, "EmailCancelamento");
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    //if (agendamento.BarbeariasId.ToString() == "1956aa91-5157-48a8-a505-7fc40129c5b1" || agendamento.BarbeariasId.ToString() == "22bb9a51-bd65-4556-8681-ecd5093e9042")
                    //{
                    //    _sms.SendSMS(agendamento.Contato, MensagemSMS.BuscaMensagem(MensagemSMS.TipoMensagem.CancelarAgendamento, agendamento));
                    //}
                    Log.Information("Agendamento cancelado ", idAgendamento);
                }

                return true;

            }
            else
            {
                throw new InvalidOperationException("Operação falhou");
            }
        }

    }
}
