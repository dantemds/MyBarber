using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System;

namespace Mybarber.Services
{
    public class SMSService
    {
        public void SendSMS()
        {
            var awsCredentials = new BasicAWSCredentials("<ACCESS_KEY>", "<SECRET_KEY>");
            var snsClient = new AmazonSimpleNotificationServiceClient(awsCredentials, RegionEndpoint.USWest2); // substitua pela região desejada
            var message = "Olá! Esta é uma mensagem SMS enviada pela AWS SNS.";
            var phoneNumber = "+55SEUNUMERODECELULAR"; // substitua pelo número de celular desejado, com o código do país (ex: +55 para o Brasil)

            var request = new PublishRequest
            {
                Message = message,
                PhoneNumber = phoneNumber
            };

            try
            {
                var response = snsClient.PublishAsync(request);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
