using Mybarber.Models;
using System;

namespace Mybarber.DesignerPatters.Strategy
{
    public class PaymentForBarber : IPayment
    {
        public bool PagarAgendamento(Agendamentos agendamentos) 
        {
            Console.WriteLine("Pagamento será realizado no estabelecimento");

            return true;
        
        
        }

    }
}
