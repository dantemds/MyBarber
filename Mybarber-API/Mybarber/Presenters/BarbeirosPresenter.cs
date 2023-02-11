using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.Exceptions;
using Mybarber.Models;
using Mybarber.Services;
using Mybarber.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mybarber.Presenter
{
    public class BarbeirosPresenter : IBarbeirosPresenter
    {
        private readonly IMapper _mapper;
        private readonly IBarbeirosServices _service;
        private readonly IServicosBarbeirosServices _servicosBarbeirosServices;
        private readonly IBarbeiroUsuarioServices _serviceUserBarbeiro;

        public BarbeirosPresenter(IBarbeirosServices service, IMapper mapper, IServicosBarbeirosServices servicosBarbeirosServices, IBarbeiroUsuarioServices serviceUserBarbeiro)
        {
            this._service = service;
            this._mapper = mapper;
            this._servicosBarbeirosServices = servicosBarbeirosServices;
            this._serviceUserBarbeiro = serviceUserBarbeiro;
        }


        //public async Task<IEnumerable<BarbeirosResponseDto>> GetAllBarbeirosAsync()
        //{
        //{
        //    try
        //    {
        //        var barbeiros = await _service.GetAllBarbeirosAsync();

        //        return _mapper.Map<IEnumerable<BarbeirosResponseDto>>(barbeiros);

        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception();
        //    }
        //}

        public async Task<BarbeirosResponseDto> GetBarbeiroAsyncById(Guid idBarbeiro)
        {
            try
            {
                var barbeiro = await _service.GetBarbeiroAsyncById(idBarbeiro);

                return _mapper.Map<BarbeirosResponseDto>(barbeiro);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<List<BarbeirosResponseDto>> GetBarbeiroAsyncByTenant(Guid idBarbearia)
        {
            try
            {
                var barbeiros = await _service.GetBarbeiroAsyncByTenant(idBarbearia);
                List<BarbeirosResponseDto> dto = new List<BarbeirosResponseDto>();
                foreach(var barbeiro in barbeiros)
                {
                    dto.Add(_mapper.Map<BarbeirosResponseDto>(barbeiro));

                }
                return dto;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<BarbeirosCompleteResponseDto> PostBarbeiroAsync(BarbeirosRequestDto barbeiroDto)
        {
            try
            {
                if (barbeiroDto.Equals(null))
                    throw new ViewException("Barbeiro.Is.Null");
                if (barbeiroDto.Password.Equals(null) || barbeiroDto.Email.Equals(null))
                    throw new ViewException("Credentials.Is.Null");




                var barbeiro = _mapper.Map<Barbeiros>(barbeiroDto);


                var usuario = await _serviceUserBarbeiro.CreateUsuarioBarbeiro(barbeiroDto);

                if (usuario == null)
                    throw new ViewException("User.Not.Saved");

                barbeiro.UsersId = usuario.IdUser;
                await _service.PostBarbeiroAsync(barbeiro);

                var barbeiroResult = await _service.GetBarbeiroAsyncById(barbeiro.IdBarbeiro);

                if (barbeiroDto.ServicosId.Any())
                {
                  await  _servicosBarbeirosServices.PostServicoBarbeirosAsyncFromBarbeiro(barbeiroDto.ServicosId, barbeiro);

                }
                var resultDto = _mapper.Map<BarbeirosCompleteResponseDto>(barbeiroResult);
                resultDto.Route = barbeiroResult.Barbearias.Route;

                return resultDto;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<BarbeirosCompleteResponseDto> DeleteBarbeiroAsyncById(Guid idBarbeiro)
        {
            try
            {
                var barbeiroFinded = await _service.GetBarbeiroAsyncById(idBarbeiro);
                //cascade 
                var usuario = await _serviceUserBarbeiro.DeleteUsuarioBarbeiro(barbeiroFinded);
                //var barbeiro = await _service.DeleteBarbeiroAsyncById(idBarbeiro);

                var barbeiroDto = _mapper.Map<BarbeirosCompleteResponseDto>(barbeiroFinded);
                barbeiroDto.Route = barbeiroFinded.Barbearias.Route;

                return barbeiroDto;
            }



            catch (Exception ex)
            {
                throw ex;
            }


        }
        //public async Task<string> UpdateBarbeiroAsyncById(int idBarbeiro) 
        //{
        //    var barbeiroFinded = await _service.GetBarbeiroAsyncById(idBarbeiro);
        //    if (!barbeiroFinded.Equals (null)) 
        //    {
        //        throw new ViewException("Barbeiro.Not.Finded");
        //    }

        //    var userFinded = await _serviceUserBarbeiro.
        
        //}





    }
}
