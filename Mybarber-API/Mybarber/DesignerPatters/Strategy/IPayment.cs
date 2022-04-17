using Mybarber.Models;

namespace Mybarber.DesignerPatters.Strategy
{
    public interface IPayment
    {

        bool PagarAgendamento(Agendamentos agendamentos);
    }
}
