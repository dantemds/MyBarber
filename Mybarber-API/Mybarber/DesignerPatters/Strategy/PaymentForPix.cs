using Mybarber.Models;
using System;

namespace Mybarber.DesignerPatters.Strategy
{
    public class PaymentForPix :IPayment
    {

        public bool PagarAgendamento(Agendamentos agendamentos)
        {
            Console.WriteLine("Pagamento será realizado por Pix");

            return true;
        }
    }
}
