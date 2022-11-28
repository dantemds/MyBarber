using Amazon.CloudFront;
using Amazon.CloudFront.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Mybarber.Helpers
{
    public class AWS
    {
        public static async Task<bool> CreateInvalidation(IConfiguration _config)
        {
            string imageToInvalidate = "/*";
            var cloudClient = new AmazonCloudFrontClient(_config.GetSection("CDNConfig:IdAcess").Value,
              _config.GetSection("CDNConfig:SecretKey").Value, Amazon.RegionEndpoint.USEast1);
            var idDistribuition = _config.GetSection("CDNConfig:cloudfrontDistributionId").Value;
            var result = await cloudClient.CreateInvalidationAsync(new CreateInvalidationRequest
            {
                DistributionId = idDistribuition,
                InvalidationBatch = new InvalidationBatch
                {
                    Paths = new Paths()
                    {
                        Items = new System.Collections.Generic.List<string> { imageToInvalidate },
                        Quantity = 1,
                    },
                    CallerReference = DateTime.Now.Ticks.ToString()

                },
            });

            if (result.HttpStatusCode.ToString() == "Created") return true;
            else throw new Exception();

        }
    }
}
