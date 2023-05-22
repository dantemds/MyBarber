using Microsoft.Extensions.Configuration;
using Mybarber.Models.Enum;
using Mybarber.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Mybarber_Test
{
    public class SmsTest
    {
        private readonly SMSService _smsService;
        public SmsTest()
        {
            var service = new SMSService();
            _smsService = service;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Api_Should_Send_SMS()
        {
            var result =  _smsService.SendSMS("11961979075", MensagemSMS.BuscaMensagem(MensagemSMS.TipoMensagem.AgendamentoBarbeiro));
            Assert.IsTrue(result);
        }
    }
}