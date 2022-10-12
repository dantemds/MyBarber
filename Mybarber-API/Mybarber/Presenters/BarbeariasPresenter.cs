using AutoMapper;
using Mybarber.DataTransferObject.Banner;
using Mybarber.DataTransferObject.Barbearia;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Contatos;
using Mybarber.DataTransferObject.Enderecos;
using Mybarber.DataTransferObject.Horario;
using Mybarber.DataTransferObject.LadingPageImages;
using Mybarber.DataTransferObject.Servico;
using Mybarber.DataTransferObject.Temas;
using Mybarber.Exceptions;
using Mybarber.Models;
using Mybarber.Services;
using Mybarber.Services.Interfaces;
using Mybarber.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenter
{
    public class BarbeariasPresenter : IBarbeariasPresenter
    {
        private readonly IMapper _mapper;
        private readonly IBarbeariasServices _service;
        private readonly ITemasServices _serviceTema;
        private readonly IEnderecosServices _serviceEnderecos;
        private readonly IContatosServices _serviceContatos;
        private readonly IHorarioFuncionamentoServices _serviceHorarioFuncionamento;
        private readonly IBannerServices _serviceBanner;
        private readonly ILandingPageServices _serviceLading;

        public BarbeariasPresenter(ILandingPageServices serviceLading, IBarbeariasServices serviceBarbearia , IMapper mapper, IEnderecosServices serviceEnderecos, ITemasServices serviceTema, IContatosServices serviceContatos, IHorarioFuncionamentoServices serviceHorarioFuncionamento, IBannerServices serviceBanner)
        {
            this._service = serviceBarbearia;
            this._mapper = mapper;
            this._serviceEnderecos = serviceEnderecos;
            this._serviceTema = serviceTema;
            this._serviceContatos = serviceContatos;
            this._serviceHorarioFuncionamento = serviceHorarioFuncionamento;
            this._serviceBanner = serviceBanner;
            this._serviceLading = serviceLading;
        }


        public async Task<IEnumerable<BarbeariasResponseDto>> GetAllBarbeariasAsync()
        {
            try
            {
                var barbearias = await _service.GetAllBarbeariasAsync();

                return _mapper.Map<IEnumerable<BarbeariasResponseDto>>(barbearias);

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<BarbeariasCompleteRequestDto> PostBarbeariaCompletaAsync(BarbeariasCompleteRequestDto dto)
        {
            try
            {
                var barbeariaDto = new BarbeariasRequestDto(dto.CNPJ, dto.NomeBarbearia, dto.Route, dto.FuncaoAgendamento);
                
                var barbearia = _mapper.Map<Barbearias>(barbeariaDto);

                await _service.PostBarbeariaAsync(barbearia);

                //-------------------------------------------------------------//

                var temaDto = new TemasRequestDto();

                temaDto = dto.Temas;

                temaDto.BarbeariasId = barbearia.IdBarbearia;

                var temas = _mapper.Map<Temas>(temaDto);

                await _serviceTema.PostTemaAsync(temas);

                //-------------------------------------------------------------//

                var enderecoDto = new EnderecosRequestDto();

                enderecoDto = dto.Enderecos;

                enderecoDto.BarbeariasId = barbearia.IdBarbearia;

                var endereco = _mapper.Map<Enderecos>(enderecoDto);

                await _serviceEnderecos.PostEnderecoAsync(endereco);

                //-------------------------------------------------------------//

                var contatoDto = new ContatosRequestDto();

                contatoDto = dto.Contatos;

                contatoDto.BarbeariasId = barbearia.IdBarbearia;

                var contato = _mapper.Map<Contatos>(contatoDto);

                await _serviceContatos.PostContatosAsync(contato);

                //-------------------------------------------------------------//

                var horarioFuncionamentoDto = new HorarioFuncionamentoRequestDto();

                horarioFuncionamentoDto = dto.HorarioFuncionamento;

                horarioFuncionamentoDto.BarbeariasId = barbearia.IdBarbearia;

                var horarioFuncionamento = _mapper.Map<HorarioFuncionamento>(horarioFuncionamentoDto);

                await _serviceHorarioFuncionamento.PostHorarioAsync(horarioFuncionamento);

                //-------------------------------------------------------------//

                ICollection<BannerRequestDto> bannerDto = new List<BannerRequestDto>() ;

                bannerDto = dto.Banner;

                foreach (BannerRequestDto item in bannerDto)
                {
                    item.BarbeariaId = barbearia.IdBarbearia;
                    await _serviceBanner.PostBannerS3Async(item);
                }
                //-------------------------------------------------------------//

                ICollection<LandingPageImagesRequestDto> landingDto = new List<LandingPageImagesRequestDto>();

                landingDto = dto.LadingPageImages;

                foreach (LandingPageImagesRequestDto item in landingDto)
                {
                    item.BarbeariaId = barbearia.IdBarbearia;
                    await _serviceLading.PostLadingPageImageS3Async(item);
                }









                return dto;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<BarbeariasResponseDto> GetAllAtributesBarbeariaAsyncById(Guid idBarbearia)
        {
            try
            {
                var barbearia = await _service.GetBarbeariaAsyncById(idBarbearia);

                var barbeariaDto =  _mapper.Map<BarbeariasResponseDto>(barbearia);
               
                return barbeariaDto;
            }
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<BarbeariasResponseDto> GetAllAtributesBarbeariaAsyncByRoute(string route)
        {
            try
            {
                var barbearia = await _service.GetBarbeariaAsyncByRoute(route);

                var barbeariaDto = _mapper.Map<BarbeariasResponseDto>(barbearia);

                return barbeariaDto;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<BarbeariasCompleteResponseDto> PostBarbeariaAsync(BarbeariasRequestDto barbeariaDto)
        {
            try { 
                if(barbeariaDto == null)
                {
                    throw new ViewException("barbearia.Missing.Info");
                }

                if(barbeariaDto.CNPJ == null)
                {
                    throw new ViewException("CNPJ.Missing.Info");
                }
                if (barbeariaDto.NomeBarbearia == null)
                {
                    throw new ViewException("Name.Barbearia.Missing.Info");
                }

                var barbearia = _mapper.Map<Barbearias>(barbeariaDto);

                await _service.PostBarbeariaAsync(barbearia);

                var b = await _service.GetBarbeariaAsyncById(barbearia.IdBarbearia);
                if(b == null)
                {
                    throw new ViewException("Operation.Failed");
                }


                return _mapper.Map<BarbeariasCompleteResponseDto>(b);
                }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
           
        }

        public async Task<string> DeleteBarbeariaAsyncById(Guid idBarbearia)
        {
            try
            {
                var barbearia = await _service.DeleteBarbeariaAsyncById(idBarbearia);

                return "Barbearia Deletada com sucesso.";
            }



            catch (Exception ex)
            {
                throw ex;
            }


        }
        public async Task<bool> PutBarbeariaAsyncById(Guid idBarbearia, BarbeariasRequestDto dto)
        {
            try
            {
                var barbearia = _mapper.Map<Barbearias>(dto);
                 await _service.PutBarbeariaAsyncById(idBarbearia, barbearia);

                return true;
            }



            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
