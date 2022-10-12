using AutoMapper;
using Mybarber.DataTransferObject.Servico;
using Mybarber.DataTransferObject.ServicoImagem;
using Mybarber.Models;
using Mybarber.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenter
{
    public class ServicosPresenter : IServicosPresenter
    {
        private readonly IMapper _mapper;
        private readonly IServicosServices _service;
        private readonly IServicoImagemServices _serviceImagem;
        public ServicosPresenter(IServicosServices service, IMapper mapper, IServicoImagemServices serviceImagem)
        {
            this._service = service;
            this._mapper = mapper;
            this._serviceImagem = serviceImagem;
        }



        public async Task<ServicosResponseDto> GetServicoAsyncById(Guid idServico)
        {
            try
            {
                var servico = await _service.GetServicoAsyncById(idServico);

                return _mapper.Map<ServicosResponseDto>(servico);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ServicosResponseDto> GetServicoAsyncByTenant(Guid idBarbearia)
        {
            try
            {
                var servicos = await _service.GetServicoAsyncByTenant(idBarbearia);
                var servicosDto = _mapper.Map<ServicosResponseDto>(servicos);
                return servicosDto;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ServicosCompleteResponseDto> PostServicoAsync(ServicosRequestDto servicoDto)
        {
            try
            {
                var servico = _mapper.Map<Servicos>(servicoDto);

                await _service.PostServicoAsync(servico);

                var b = await _service.GetServicoAsyncById(servico.IdServico);



                return _mapper.Map<ServicosCompleteResponseDto>(b);

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


        public async Task<bool> PostServiceCompleteAsync(ServicosCompleteRequestDto servicoDto)
        {
            
                
            ServicosRequestDto dto = new ServicosRequestDto()
            {
                BarbeariasId = servicoDto.BarbeariasId,
                NomeServico = servicoDto.NomeServico,
                PrecoServico = servicoDto.PrecoServico,
                TempoServico = servicoDto.TempoServico,
                
            };
            var servico = _mapper.Map<Servicos>(dto);


            var imageDto = new ServicoImagemRequestS3Dto() { 
            File = servicoDto.File,
            Route = servicoDto.Route,
            NomeImagem = servicoDto.NomeServico,
            IdServico = servico.IdServico
            };
            var imagem =  await _serviceImagem.PostServicoImagemS3Async(imageDto);

            

            var servicoSalvo = await _service.PostServicoAsync(servico);

            if (servicoSalvo != null)
            {
                return true;
            }
            else { return false;  }

           
        }

        public async Task<string> DeleteServicoAsyncById(Guid idServico)
        {
            try
            {
                var service = await _service.DeleteServicoAsyncById(idServico);

                return "Servico Deletado com sucesso.";
            }



            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
