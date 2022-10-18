using AutoMapper;
using Mybarber.DataTransferObject.Relacionamento;
using Mybarber.Models;
using Mybarber.Presenters.Interfaces;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public class RolesUsersPresenter: IRolesUsersPresenter
    {
        private readonly IMapper _mapper;
        private readonly IRolesUsersServices _services;


        public RolesUsersPresenter(IMapper mapper, IRolesUsersServices services)
        {
            this._mapper = mapper;
            this._services = services;
        }
        public async Task<UsersRolesResponseDto> PostRelacionamentoAsync(UsersRolesRequestDto relacionamentoDto)
        {
            try
            {
                var relacionamento = _mapper.Map<RolesUsers>(relacionamentoDto);

                await _services.PostRelacionamentoAsync(relacionamento);



                return _mapper.Map<UsersRolesResponseDto>(relacionamentoDto);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
