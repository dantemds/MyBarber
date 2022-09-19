using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using Mybarber.DataTransferObject.LadingPageImages;
using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class LandingPageServices: ILandingPageServices
    {
        private readonly IConfiguration _config;
        private readonly IGenerallyRepository _generally;
        public LandingPageServices(IGenerallyRepository generally, IConfiguration config)
        {
            this._generally = generally;
            this._config = config;
        }


        public async Task<List<LandingPageImages>> PostListLandingPageS3Async(List<LandingPageImagesRequestDto> list)
        {
            List<LandingPageImages> listaRetorno = new List<LandingPageImages>();

            for (int i = 0; i < list.Count; i++)
            {
                var result = await PostLadingPageImageS3Async(list[i]);

                listaRetorno.Add(result);

            }

            return listaRetorno;
        }

            
        public async Task<LandingPageImages> PostLadingPageImageS3Async(LandingPageImagesRequestDto dto)
        {
            string bucketName = _config.GetSection("S3Config:BucketName").Value;

            var client = new AmazonS3Client(_config.GetSection("S3Config:IdAcess").Value, _config.GetSection("S3Config:SecretKey").Value, Amazon.RegionEndpoint.USEast1);


            try
            {
                var findFolderRequest = new ListObjectsV2Request();
                findFolderRequest.BucketName = bucketName;
                findFolderRequest.Prefix = _config.GetSection("S3Config:ImagesLanding").Value + dto.Route;
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
                        Key = _config.GetSection("S3Config:ImagesLanding").Value + dto.Route + "/",
                        ContentBody = string.Empty
                    };
                    PutObjectResponse responseStore = await client.PutObjectAsync(request);
                }



                var putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = _config.GetSection("S3Config:ImagesLanding").Value + dto.Route + "/" + dto.Posicao + "/" + dto.NumeroImagem + "/" + dto.BarbeariaId,
                    InputStream = dto.File.OpenReadStream(),

                };
                putRequest.Metadata.Add("Content-Type", dto.File.ContentType);
                PutObjectResponse response = await client.PutObjectAsync(putRequest);


                var imagemLanding = new LandingPageImages();

                imagemLanding.NumeroImagem = dto.NumeroImagem;
                imagemLanding.Especificacao =dto.Especificacao;
                imagemLanding.Posicao =dto.Posicao;
                imagemLanding.Name = dto.Name;
                imagemLanding.BarbeariasId = dto.BarbeariaId;
                imagemLanding.URL = _config.GetSection("S3Config:ImagesLanding").Value + dto.Route + "/" + dto.Posicao + "/" + dto.NumeroImagem + "/" + dto.BarbeariaId;

                _generally.Add(imagemLanding);

                if (await _generally.SaveChangesAsync())
                {
                    return imagemLanding;
                }
                else
                {
                    return imagemLanding;
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
