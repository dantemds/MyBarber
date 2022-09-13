using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using Mybarber.DataTransferObject.Banner;
using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class BannerServices : IBannerServices
    {
        private readonly IGenerallyRepository _generally;
        private readonly IConfiguration _config;
        public BannerServices(IGenerallyRepository generally, IConfiguration config)
        {
            this._generally = generally;
            this._config = config;
        }

        public async Task<Banner> PostBannerS3Async(BannerRequestDto banner)
        {

            string bucketName = _config.GetSection("S3Config:BucketName").Value;

            var client = new AmazonS3Client(_config.GetSection("S3Config:IdAcess").Value, _config.GetSection("S3Config:SecretKey").Value, Amazon.RegionEndpoint.USEast1);


            try
            {
                var findFolderRequest = new ListObjectsV2Request();
                findFolderRequest.BucketName = bucketName;
                findFolderRequest.Prefix = _config.GetSection("S3Config:ImagesBanner").Value + banner.Route;
                findFolderRequest.MaxKeys = 1;


                ListObjectsV2Response findFolderResponse =
           await client.ListObjectsV2Async(findFolderRequest);

                if (findFolderResponse.S3Objects.Count <= 0)
                {
                    PutObjectRequest request = new PutObjectRequest()
                    {
                        BucketName = bucketName,
                        StorageClass = S3StorageClass.Standard,
                        ServerSideEncryptionMethod = ServerSideEncryptionMethod.None,
                        Key = _config.GetSection("S3Config:ImagesBanner").Value + banner.Route + "/",
                        ContentBody = string.Empty
                    };
                    PutObjectResponse responseStore = await client.PutObjectAsync(request);
                }



                var putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = _config.GetSection("S3Config:ImagesBanner").Value + banner.Route + "/" + banner.BarbeariaId,
                    InputStream = banner.File.OpenReadStream(),

                };
                putRequest.Metadata.Add("Content-Type", banner.File.ContentType);
                PutObjectResponse response = await client.PutObjectAsync(putRequest);


                var imagemBanner = new Banner();

                imagemBanner.Name = banner.NomeImagem;
                imagemBanner.BarbeariasId = banner.BarbeariaId;
                imagemBanner.URL = _config.GetSection("S3Config:ImagesBanner").Value + banner.Route + "/" + banner.BarbeariaId;

                _generally.Add(imagemBanner);

                if (await _generally.SaveChangesAsync())
                {
                    return imagemBanner;
                }
                else
                {
                    return imagemBanner;
                }


            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }
    }
}
