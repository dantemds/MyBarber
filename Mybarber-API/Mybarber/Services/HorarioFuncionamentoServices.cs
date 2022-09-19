using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class HorarioFuncionamentoServices:IHorarioFuncionamentoServices
    {
        private readonly IGenerallyRepository _generally;
        public HorarioFuncionamentoServices(IGenerallyRepository generally)
        {
            this._generally = generally;
        }

        public async Task<HorarioFuncionamento> PostHorarioAsync(HorarioFuncionamento horario)
        {
            _generally.Add(horario);
            if (await _generally.SaveChangesAsync())
            {
                return horario;
            }
            else
            {
                throw new Exception();
            }
        }
}
