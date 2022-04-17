using AutoMapper;
using Mybarber.DataTransferObject.Relacionamento;
using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public class ServicosBarbeirosPresenter : IServicosBarbeirosPresenter
    {
        private readonly IMapper _mapper;
      
        private readonly IServicosBarbeirosServices _servicosBarbeirosServices;
        public ServicosBarbeirosPresenter(IMapper mapper, IServicosBarbeirosServices servicosBarbeirosServices)
        {
           
            this._mapper = mapper;
            this._servicosBarbeirosServices = servicosBarbeirosServices;
        }

        public async Task<ServicosBarbeirosRequestDto> PostServicoBarbeirosAsync(ServicosBarbeirosRequestDto relacionamentoDto)
        {
            try
            {
                


                var relacionamento =   _mapper.Map<ServicosBarbeiros>(relacionamentoDto);

                await _servicosBarbeirosServices.PostServicoBarbeirosAsync(relacionamento);

                return relacionamentoDto;

               


            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


    }
}
