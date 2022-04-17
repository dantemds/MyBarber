using AutoMapper;
using Mybarber.DataTransferObject.Barbearia;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Servico;
using Mybarber.Exceptions;
using Mybarber.Models;
using Mybarber.Services;
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
     
        public BarbeariasPresenter(IBarbeariasServices serviceBarbearia , IMapper mapper
     )
        {
            this._service = serviceBarbearia;
            this._mapper = mapper;
     

        }


        //public async Task<IEnumerable<BarbeariasResponseDto>> GetAllBarbeariasAsync()
        //{
        //    try
        //    {
        //        var barbearias = await _service.GetAllBarbeariasAsync();

        //        return _mapper.Map<IEnumerable<BarbeariasResponseDto>>(barbearias);

        //    }catch (Exception)
        //    {
        //        throw new Exception();
        //    }
        //}
        
        public async Task<BarbeariasResponseDto> GetAllAtributesBarbeariaAsyncById(int idBarbearia)
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

        public async Task<string> DeleteBarbeariaAsyncById(int idBarbearia)
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
        public async Task<bool> PutBarbeariaAsyncById(int idBarbearia, BarbeariasRequestDto dto)
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
