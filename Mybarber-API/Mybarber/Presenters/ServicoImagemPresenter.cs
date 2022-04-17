using AutoMapper;
using Mybarber.DataTransferObject.Images;
using Mybarber.Models;
using Mybarber.Services;
using System;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public class ServicoImagemPresenter : IServicoImagemPresenter
    {
      
        
            private readonly IMapper _mapper;
            private readonly IServicoImagemServices _service;

            public ServicoImagemPresenter(IServicoImagemServices service, IMapper mapper
         )
            {
                this._service = service;
                this._mapper = mapper;

            }

        public async Task<ServicoImagemRequestDto> PostServicoImagemAsync(ServicoImagemRequestDto imagemDto)
        {
            try
            {
                var imagem = _mapper.Map<ServicoImagens>(imagemDto);

                await _service.PostServicoImagemAsync(imagem);


                return imagemDto;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
