using Mybarber.Exceptions;
using Mybarber.Exceptions.Tradutor;
using Mybarber.Models;
using Mybarber.Repository;
using System;
using System.Globalization;
using System.Threading.Tasks;
using static Mybarber.Exceptions.ViewException;

namespace Mybarber.Services
{
    public class AgendasServices : IAgendasServices
    {
        private readonly IGenerallyRepository _generally;
        private readonly IBarbeirosRepository _repo;

        public AgendasServices( IGenerallyRepository generally, IBarbeirosRepository repo)
        {
            
            this._generally = generally;
            this._repo = repo;

        }

        public async Task<Agendas> PostAgendaAsync(Agendas agenda)
        {
            try
            {
                


                _generally.Add(agenda);

                if (await _generally.SaveChangesAsync())
                {

                    return agenda;
                }
                else
                {
                    throw new DbException(TraslateExceptions.NotSaved);
                }
            }
            catch (Exception ex)
            {
                throw new ViewException("Operation.Failed", ex.Message);
            }
        }



       

    }
}
