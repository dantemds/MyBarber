using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IAgendasServices
    {
        Task<Agendas> PostAgendaAsync(Agendas agenda);
    }
}
