using Dapper;
using Mybarber.Models;
using Npgsql;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.DAO
{
    public class BarbeariasDAO
    {
        private readonly NpgsqlConnection _npg;


        public BarbeariasDAO(NpgsqlConnection npg)
        {
            this._npg = npg;
        }
        public async Task<Barbearias> GetBarbeariasAsyncById(Guid idBarbearia)
        {
            var query = (await _npg.QueryAsync<Barbearias>(
                $@"Select  * From public.""Barbearias""
                INNER JOIN public.""Barbeiros"" ON public.""Barbearias"".""IdBarbearia"" = public.""Barbeiros"".""BarbeariasId""
                inner join public.""Servicos"" on public.""Barbearias"".""IdBarbearia"" = public.""Servicos"".""BarbeariasId"" 
                inner join public.""BarbeiroImagens"" on public.""Barbeiros"".""BarbeiroImagemId"" = public.""BarbeiroImagens"".""IdBarbeiroImagem""
                inner join public.""ServicoImagens"" on public.""Servicos"".""ServicoImagemId"" = public.""ServicoImagens"".""IdImagemServico""
                inner join public.""ServicosBarbeiros"" on public.""Barbearias"".""IdBarbearia"" = public.""ServicosBarbeiros"".""BarbeariasId""
                Where public.""Barbearias"".""IdBarbearia""  =  @{idBarbearia}; ")).AsQueryable();

            return query.SingleOrDefault();
        
        }
    }
}
