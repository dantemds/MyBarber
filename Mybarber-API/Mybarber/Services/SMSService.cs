using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Extensions.Configuration;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class SMSService: ISMSService
    {
        private readonly IConfiguration _config;
        public SMSService(IConfiguration config)
        {
            this._config = config;
        }
        public SMSService()
        {

        }
        public  bool SendSMS(string phoneNumber, string message)
        {
            //var awsCredentials = new BasicAWSCredentials(_config.GetSection("Key:SmsUser").Value, _config.GetSection("Key:SmsPass").Value);
            var awsCredentials = new BasicAWSCredentials("AKIAYIZRZPXD2MYUBX7J", "RRqcdenWaeydvZOaNQGc1RZEIyv/M9qxZO7UIg3j");
            var snsClient = new AmazonSimpleNotificationServiceClient(awsCredentials, RegionEndpoint.USEast1); 

            if (phoneNumber.Length >= 11)
            {
                phoneNumber = "+55" + phoneNumber;
            }

            var request = new PublishRequest
            {
                Message = message,
                PhoneNumber = phoneNumber
            };

            try
            {
                var response = snsClient.PublishAsync(request).Result;
                if (response != null)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
