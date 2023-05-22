using Mybarber.Models;
using Mybarber.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber_Test
{
    public class AgendamentoTest
    {
        private readonly IAgendamentosServices _services;
        public AgendamentoTest(IAgendamentosServices services)
        {
            this._services = services;
        }
        [Test]
        public void Api_Should_Send_SMS()
        {
            Agendamentos agendamento = new Agendamentos();
            var result =  _services.PostAgendamentoAsync(agendamento);
            Assert.IsTrue(result != null);
        }
    }
}
