using System.Collections.Generic;

namespace Mybarber.Models.Enum
{
    
    public static class MensagemSMS
    {

        public enum TipoMensagem { 
            CancelarAgendamento,
            AgendamentoBarbeiro,
            AgendamentoCliente        
        }
        

        public static string BuscaMensagem(TipoMensagem tipo, Agendamentos agendamentos)
        {
            var data = agendamentos.ToStringData();
            var hora = agendamentos.ToStringHora();

            if (MensagemSMS.TipoMensagem.AgendamentoBarbeiro == tipo)
            {
                return "Você tem um novo agendamento!\n\n" + hora + " " + data + "\n\nMinha Barbearia Online";
            } else if (MensagemSMS.TipoMensagem.AgendamentoCliente == tipo)
            {
                return "Minha Barbearia Online\nOlá! Seu agendamento foi efetuado com SUCESSO!\n" + hora + " "+ data;
            } else if (MensagemSMS.TipoMensagem.CancelarAgendamento == tipo)
            {
                return "Minha Barbearia Online\nSentimos muito, mas infelizemente seu agendamento para o dia " + data  + " e hora " + hora + " foi cancelado!";
            }
            return "";
        }
    }
}
