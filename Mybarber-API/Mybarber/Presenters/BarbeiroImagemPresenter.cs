using AutoMapper;
using Mybarber.DataTransferObject.Barbearia;
using Mybarber.DataTransferObject.Images;
using Mybarber.Models;
using Mybarber.Services;
using System;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public class BarbeiroImagemPresenter : IBarbeiroImagemPresenter
    {
        private readonly IMapper _mapper;
        private readonly IBarbeiroImagemServices _service;

        public BarbeiroImagemPresenter(IBarbeiroImagemServices service, IMapper mapper
     )
        {
            this._service = service;
            this._mapper = mapper;


        }
        public async Task<BarbeiroImagemRequestDto> PostBarbeiroImagemAsync(BarbeiroImagemRequestDto imagemDto)
        {
            try
            {
                var imagem = _mapper.Map<BarbeiroImagens>(imagemDto);

                await _service.PostBarbeiroImagemAsync(imagem);





                return imagemDto ;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }




    }
}
