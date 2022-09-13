using Mybarber.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IAgendasServices
    {
        Task<Agendas> PostAgendaAsync(Agendas agenda);
        Task<List<float>> PopularHorario(Guid idBarbeiro, string dia, DateTime data, Guid tenant, Guid idServico);
       
        //Task<List<float>> ExcluirHorariosAgendados(List<float> agenda, DateTime data, int idServico, int tenant);
    }
}
