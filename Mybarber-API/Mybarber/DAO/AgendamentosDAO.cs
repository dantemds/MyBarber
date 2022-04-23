using Dapper;
using Mybarber.Helpers;
using Mybarber.Models;
using Npgsql;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.DAO
{
    public class AgendamentosDAO
    {

        private readonly NpgsqlConnection _npg;


        public AgendamentosDAO(NpgsqlConnection npg)
        {
            this._npg = npg;
        }


        public async Task<PageList<Agendamentos>> GetAgendamentosAsyncByTenant(int tenant, PageParams pageParams)
        {
           
            var query = (await _npg.QueryAsync<Agendamentos>(
                $@"SELECT *
                FROM public.""Agendamentos""
                where ""BarbeariasId"" = @{tenant};"

                )).AsQueryable();
            

            if (!string.IsNullOrEmpty(pageParams.NomeBarbeiro))
                query = query.Where(agendamento => agendamento.Barbeiros.NameBarbeiro.ToUpper().Equals(pageParams.NomeBarbeiro.ToUpper()));
            if (!string.IsNullOrEmpty(pageParams.NomeServico))
                query = query.Where(agendamento => agendamento.Servicos.NomeServico.ToUpper().Equals(pageParams.NomeServico.ToUpper()));

            if ((pageParams.Date.Day.Equals(DateTime.Now.Day)) && (pageParams.Date.Month.Equals(DateTime.Now.Month)) && (pageParams.Date.Year.Equals(DateTime.Now.Year)))
                query = query.Where
                (agendamento => (agendamento.Horario.Day.Equals(pageParams.Date.Day) && agendamento.Horario.Month.Equals(pageParams.Date.Month)
                && agendamento.Horario.Year.Equals(pageParams.Date.Year)));

            if (!pageParams.Date.Day.Equals(DateTime.Now.Day))
                query = query.Where(agendamentos => agendamentos.Horario.Day.Equals(pageParams.Date.Day)
                && agendamentos.Horario.Month.Equals(pageParams.Date.Month) && agendamentos.Horario.Year.Equals(pageParams.Date.Year));

            if (!query.Any()) { query=null; }
            return await PageList<Agendamentos>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }


    }
}
