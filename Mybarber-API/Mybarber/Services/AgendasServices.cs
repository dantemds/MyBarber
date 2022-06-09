using Mybarber.Exceptions;
using Mybarber.Exceptions.Tradutor;
using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static Mybarber.Exceptions.ViewException;

namespace Mybarber.Services
{
    public class AgendasServices : IAgendasServices
    {
        private readonly IGenerallyRepository _generally;
        private readonly IBarbeirosRepository _repo;
        private readonly IServicosRepository _servicoRepo;
        private readonly IAgendamentosRepository _agendamentosRepo;

        public AgendasServices( IGenerallyRepository generally, IBarbeirosRepository repo, IServicosRepository servicoRepo, IAgendamentosRepository agendamentosRepo)
        {
            this._agendamentosRepo = agendamentosRepo;
            this._generally = generally;
            this._repo = repo;
            this._servicoRepo = servicoRepo;
            

        }

        public async Task<Agendas> PostAgendaAsync(Agendas agenda)
        {
            try
            {
                


                _generally.Add(agenda);

                if (await _generally.SaveChangesAsync())
                {

                    return agenda;
                }
                else
                {
                    throw new DbException(TraslateExceptions.NotSaved);
                }
            }
            catch (Exception ex)
            {
                throw new ViewException("Operation.Failed", ex.Message);
            }
        }
        public async Task<List<float>> PopularHorario(int idBarbeiro, string dia, DateTime data, int tenant, int idServico)
        {
            List<float> agenda = new List<float>();
            var HorarioMin=0.0f;
            var HorarioMax=0.0f;
            var barbeiro = await _repo.GetBarbeirosAsyncById(idBarbeiro);
            var brasilia = TimeZoneInfo.FindSystemTimeZoneById("Brazil/East");
            var horaBrasilia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.Now, brasilia);
            var horaAtual = (horaBrasilia.Hour.ToString() + '.' + horaBrasilia.Minute.ToString());
            if (DateTime.Now.Day == data.Day)
            {
                

                if (horaAtual[3] == '3' || horaAtual[3] == '4' || horaAtual[3] == '5')
                {

                    horaAtual = horaAtual.Substring(0, 2) + '.' + "51";
                }
            }
           



            var horaAtualFloat = Convert.ToSingle(horaAtual);
            

            switch (dia)
            {
                case "domingo":
                    HorarioMin = barbeiro.Agendas.Domingo[0];
                    HorarioMax = barbeiro.Agendas.Domingo[1];
                    
                    break;
                case "segunda":
                    HorarioMin = barbeiro.Agendas.Segunda[0];
                    HorarioMax = barbeiro.Agendas.Segunda[1];
                    
                    break;
                case "terca":
                    HorarioMin = barbeiro.Agendas.Terca[0];
                    HorarioMax = barbeiro.Agendas.Terca[1];
                   
                    break;
                case "quarta":
                    HorarioMin = barbeiro.Agendas.Quarta[0];
                    HorarioMax = barbeiro.Agendas.Quarta[1];
                    
                    break;
                case "quinta":
                    HorarioMin = barbeiro.Agendas.Quinta[0];
                    HorarioMax = barbeiro.Agendas.Quinta[1];
                    
                    break;
                case "sexta":
                    HorarioMin = barbeiro.Agendas.Sexta[0];
                    HorarioMax = barbeiro.Agendas.Sexta[1];
                    
                    break;
                case "sabado":
                    HorarioMin = barbeiro.Agendas.Sabado[0];
                    HorarioMax = barbeiro.Agendas.Sabado[1];
                   
                    break;
            }


           for (float i = HorarioMin; i < HorarioMax; i += 0.5f)
            {
                if (DateTime.Now.Day == data.Day)
                {
                    if (horaAtualFloat < i)
                    {
                        agenda.Add(i);
                    }

                }
                else
                {
                    agenda.Add(i);
                }
                
            }
            var result = await ExcluirHorariosAgendados(agenda, data, idServico, tenant, barbeiro.IdBarbeiro);
            return result;

        }


       

        private async Task<List<float>> ExcluirHorariosAgendados(List<float> agenda, DateTime data, int idServico, int tenant,int idBarbeiro)
        {
            var servico = await _servicoRepo.GetServicosAsyncById(idServico);
            PageParams pageParams = new PageParams();
            pageParams.Date = data;
            Console.WriteLine("--------------duracaoServico  EM STRING---------------");
            var durancaoServico = servico.TempoServico.Hour.ToString() + '.' + servico.TempoServico.Minute.ToString();
            Console.WriteLine(durancaoServico);
            durancaoServico = durancaoServico.Replace("30", "5");

            Console.WriteLine("--------------duracaoServico  EM Float---------------");
            var duracaoServicoFloat = Convert.ToSingle(durancaoServico);
            Console.WriteLine(duracaoServicoFloat);
            var agendamentos = await _agendamentosRepo.GetAgendamentosAsyncByTenant(tenant, pageParams);
           
            
            foreach(var item in agenda.ToArray())
            {
                foreach(var agendamento in agendamentos.ToArray())
                {
                    if (agendamento.BarbeirosId == idBarbeiro)
                    {

                        var hora = agendamento.Horario.Hour.ToString() + '.' + agendamento.Horario.Minute.ToString();
                        hora.Replace("30", "5");
                        var horaFloat = Convert.ToSingle(hora);
                        if (item == horaFloat)
                        {
                            var durancaoServicoAgendado = agendamento.Servicos.TempoServico.Hour.ToString() + '.' + agendamento.Servicos.TempoServico.Minute.ToString();
                            durancaoServicoAgendado = durancaoServicoAgendado.Replace("30", "5");
                            var duracaoServicoAgendadoFloat = Convert.ToSingle(durancaoServicoAgendado);
                            var itensExcluidos = (int)(duracaoServicoAgendadoFloat / 0.5);

                            var index = agenda.IndexOf(item);
                            agenda.RemoveRange(index, itensExcluidos);
                        }
                    }
                }
            }

           var agendaFinal= ExcluirHorariosDuracaoServico(agenda, duracaoServicoFloat);



            return agendaFinal;
        }


        private  List<float> ExcluirHorariosDuracaoServico(List<float> agenda, float  duracaoServico)
        {
            var result = new List<float>();
            var valoresDaAgenda = agenda.Count();
            var duracaoServicoCalculado = (int)(duracaoServico / 0.5f);
            var indexMax = valoresDaAgenda - duracaoServicoCalculado;
            var listaArrancaveis = new List<float>();
            foreach(var item in agenda.ToArray())
            {
                if (agenda.IndexOf(item) <= indexMax)
                {


                    if ((agenda[agenda.IndexOf(item)] + (duracaoServico - 0.5f) == agenda[agenda.IndexOf(item) + (int)((duracaoServico / 0.5f) - 1.0f)]))
                    {
                        //var lista = new List<float>();
                        //lista.Add(agenda.GetRange(agenda.IndexOf(item), (int)((duracaoServico / 0.5f) - 1.0f)));

                        //listaArrancaveis.AddRange(agenda.GetRange(agenda.IndexOf(item), (int)((duracaoServico / 0.5f) - 1.0f)));
                        //agenda.RemoveRange(agenda.IndexOf(item), (int)((duracaoServico / 0.5f) - 1.0f));
                        result.Add(item);
                    }
                    
                }
            }
            


            return result;
        }
       

    }
}
