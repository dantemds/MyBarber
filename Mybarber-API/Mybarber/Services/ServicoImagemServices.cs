using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Mybarber.DataTransferObject.ServicoImagem;
using Mybarber.Models;
using Mybarber.Repositories.Interface;
using Mybarber.Repository;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class ServicoImagemServices : IServicoImagemServices
    {
        private readonly IGenerallyRepository _generally;
        private readonly IConfiguration _config;
        private readonly IServicoImagemRepository _repository;
        public ServicoImagemServices( IGenerallyRepository generally, IConfiguration config, IServicoImagemRepository repository)
        {
            this._repository = repository;
            this._generally = generally;
            this._config = config;

        }

        public async Task<bool> DeleteServicoImagemS3Async(string route, Guid idServico)
        {
            string bucketName = _config.GetSection("S3Config:BucketName").Value;


            var client = new AmazonS3Client(_config.GetSection("S3Config:IdAcess").Value, _config.GetSection("S3Config:SecretKey").Value, Amazon.RegionEndpoint.USEast1);

            try
            {
                var imagem = await _repository.GetImagemServicoByIdServico(idServico);

                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = _config.GetSection("S3Config:ImagesServico").Value + route + "/" + idServico
                };

                await client.DeleteObjectAsync(deleteObjectRequest);

                _generally.Delete(imagem);

                if (await _generally.SaveChangesAsync())
                {
                    return true;
                }
                else
                {
                    return false;
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

        public async Task<ServicoImagens> PostServicoImagemS3Async(ServicoImagemRequestS3Dto dto)
        {

            string bucketName = _config.GetSection("S3Config:BucketName").Value;


            var client = new AmazonS3Client(_config.GetSection("S3Config:IdAcess").Value, _config.GetSection("S3Config:SecretKey").Value, Amazon.RegionEndpoint.USEast1);

            try
            {
                var findFolderRequest = new ListObjectsV2Request();
                findFolderRequest.BucketName = bucketName;
                findFolderRequest.Prefix = _config.GetSection("S3Config:ImagesServico").Value + dto.Route;
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
                        Key = _config.GetSection("S3Config:ImagesServico").Value + dto.Route + "/",
                        ContentBody = string.Empty
                    };
                    PutObjectResponse responseStore = await client.PutObjectAsync(request);
                }



                var putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = _config.GetSection("S3Config:ImagesServico").Value + dto.Route + "/" + dto.IdServico,
                    InputStream = dto.File.OpenReadStream(),

                };
                putRequest.Metadata.Add("Content-Type", dto.File.ContentType);
                PutObjectResponse response = await client.PutObjectAsync(putRequest);


                var imagemServico = new ServicoImagens();
                
                imagemServico.Name = dto.NomeImagem;
                imagemServico.IdImagemServico = dto.IdServico;
                imagemServico.ServicosId = dto.IdServico;
                imagemServico.URL = _config.GetSection("S3Config:ImagesServico").Value + dto.Route + "/" + dto.IdServico;

                 _generally.Add(imagemServico);

                if (await _generally.SaveChangesAsync())
                {
                    return imagemServico;
                }
                else
                {
                    return imagemServico;
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

        public async Task<bool> PutServicoImagemS3Async(ServicoImagemRequestS3Dto dto)
        {

            string bucketName = _config.GetSection("S3Config:BucketName").Value;


            var client = new AmazonS3Client(_config.GetSection("S3Config:IdAcess").Value, _config.GetSection("S3Config:SecretKey").Value, Amazon.RegionEndpoint.USEast1);

            try
            {
                var imagemAnterior = await _repository.GetImagemServicoByIdServico(dto.IdServico);

                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = _config.GetSection("S3Config:ImagesServico").Value + dto.Route + "/" + dto.IdServico
                };

                await client.DeleteObjectAsync(deleteObjectRequest);

                var putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = _config.GetSection("S3Config:ImagesServico").Value + dto.Route + "/" + dto.IdServico,
                    InputStream = dto.File.OpenReadStream(),

                };

                putRequest.Metadata.Add("Content-Type", dto.File.ContentType);

                PutObjectResponse response = await client.PutObjectAsync(putRequest);

                imagemAnterior.URL = _config.GetSection("S3Config:ImagesServico").Value + dto.Route + "/" + dto.IdServico;

                _generally.Update(imagemAnterior);
                if (await _generally.SaveChangesAsync())
                {
                    return true;
                }
                else
                {
                    return false;
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

        public async Task<ServicoImagens> PostServicoImagemAsync(ServicoImagens imagem)
        {
            try
            {
                _generally.Add(imagem);

                if (await _generally.SaveChangesAsync())
                {

                    return imagem;
                }
                else
                {
                    throw new InvalidOperationException("Operação falhou");
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
