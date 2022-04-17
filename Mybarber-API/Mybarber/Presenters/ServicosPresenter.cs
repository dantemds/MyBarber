using AutoMapper;
using Mybarber.DataTransferObject.Servico;
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
        public ServicosPresenter(IServicosServices service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }



        public async Task<ServicosResponseDto> GetServicoAsyncById(int idServico)
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

        public async Task<ServicosResponseDto> GetServicoAsyncByTenant(int idBarbearia)
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

        public async Task<string> DeleteServicoAsyncById(int idServico)
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
