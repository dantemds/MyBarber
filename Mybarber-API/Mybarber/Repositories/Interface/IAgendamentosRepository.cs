using Mybarber.DataTransferObject.Agendamento;
using Mybarber.Helpers;
using Mybarber.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Repository
{
    public interface IAgendamentosRepository
    {

        //AGENDAMENTO
        Task<Agendamentos[]> GetAllAgendamentosAsync();
        Task<Agendamentos> GetAgendamentosAsyncById(int idAgendamento);
        Task<PageList<Agendamentos>> GetAgendamentosAsyncByTenant(Guid tenant, PageParams pageParams);
        Task<Agendamentos> GetAgendamentosAsyncByHorario(Agendamentos horario);
        Task<IEnumerable<AgendamentosDoBarbeiro>> GetAgendamentosAsyncByIdBarbeiro(DateTime data, Guid idBarbeiro, Guid tenant);
        Task<PageList<Agendamentos>> GetAgendamentosAsyncByTenantDAO(Guid tenant, PageParams pageParams);
        Task<Agendamentos[]> GetAgendamentosApartirDeByBarbeiro(DateTime data, Guid idBarbeiro);
    }
}
