using Mybarber.Models;

namespace Mybarber.DesignerPatters.Strategy
{
    public class PaymentContextStrategy
    {
        private  IPayment _payment;
        public PaymentContextStrategy(IPayment payment) 
        {
        this._payment = payment;
        }

        public void DefineStrategy(IPayment payment) 
        {
            this._payment = payment; 
        }
        public void PagaAgendamento(Agendamentos agendamentos)
        {

            _payment.PagarAgendamento(agendamentos);
        }

    }
}
