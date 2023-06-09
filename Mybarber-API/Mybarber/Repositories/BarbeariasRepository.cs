using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repository;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Mybarber.DAO;
using Mybarber.DataTransferObject.Barbearia;

namespace Mybarber.Repositories
{
    public class BarbeariasRepository : IBarbeariasRepository

    {
        private readonly Context _context;

        public BarbeariasRepository(Context context)
        {
            _context = context;
        }

        //-----------------------------------------------------------------------------------------------------//

        public async Task<Barbearias[]> GetAllBarbeariasAsync()
        {
            try
            {
                IQueryable<Barbearias> query = _context.Barbearias.Include(p => p.Barbeiros)
                    .Include(p => p.Servicos)
                    .Include(p => p.ServicosBarbeiros);

                query = query.AsNoTracking()
                             .OrderBy(barbearias => barbearias.IdBarbearia);

                return await query.ToArrayAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public async Task<Barbearias> GetBarbeariasAsyncById(Guid idBarbearia)
        {
            try
            {

                IQueryable<Barbearias> query = _context.Barbearias.Include(p => p.Barbeiros).ThenInclude(it => it.BarbeiroImagem).Include(it => it.Barbeiros).ThenInclude(it => it.Agendas)
                    .Include(p => p.Servicos).ThenInclude(it => it.ServicoImagem)
                    .Include(it => it.Servicos).ThenInclude(it => it.ServicosBarbeiros).ThenInclude(it => it.Barbeiros).ThenInclude(it => it.BarbeiroImagem)
                    .Include(it => it.Servicos).ThenInclude(it => it.ServicosBarbeiros).ThenInclude(it => it.Barbeiros).ThenInclude(it => it.Agendas)
                .Include(it => it.Agendamentos).ThenInclude(it => it.Servicos)
                .Include(it => it.Agendamentos).ThenInclude(it => it.Barbeiros).Include(it=>it.Temas).Include(it=>it.Contatos).Include(it=>it.HorarioFuncionamento);


                query = query.AsNoTracking()

                    .OrderBy(barbearias => barbearias.IdBarbearia)
                    .Where(barbearias => barbearias.IdBarbearia == idBarbearia);

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception();

            }
        }


       


        public async Task<Barbearias> GetBarbeariasAsyncByRoute(string route)
        {
            try
            {

                IQueryable<Barbearias> query = _context.Barbearias./*Include(p=>p.Tema).Include(p=>p.Contatos).Include(p=>p.Endereco).*/Include(p => p.Barbeiros).ThenInclude(it => it.BarbeiroImagem).Include(it => it.Barbeiros).ThenInclude(it => it.Agendas)
                    .Include(p => p.Servicos).ThenInclude(it => it.ServicoImagem)
                    .Include(it => it.Servicos).ThenInclude(it => it.ServicosBarbeiros).ThenInclude(it => it.Barbeiros).ThenInclude(it => it.BarbeiroImagem)
                    .Include(it => it.Servicos).ThenInclude(it => it.ServicosBarbeiros).ThenInclude(it => it.Barbeiros).ThenInclude(it => it.Agendas)
                .Include(it => it.Agendamentos).ThenInclude(it => it.Servicos)
                .Include(it => it.Agendamentos).ThenInclude(it => it.Barbeiros).Include(it=> it.Temas).Include(it=> it.Contatos).Include(it=> it.Enderecos).Include(it=>it.HorarioFuncionamento).Include(it=>it.Banner).Include(it=>it.LandingPageImages)
                .Include(it=>it.Aviso).Include(it => it.BarbeariasCondicoes).ThenInclude(it => it.Condicao);


                query = query.AsNoTracking()

                    .OrderBy(barbearias => barbearias.IdBarbearia)
                    .Where(barbearias => barbearias.Route == route);
                var result = await query.FirstOrDefaultAsync();
                result.Servicos = result.Servicos.OrderBy(s => s.Ordem).ToList();
                return result;
            }
            catch (Exception)
            {
                throw new Exception();

            }
        }
        public async Task<Barbearias> GetBarbeariasAsyncByIdDAO(Guid idBarbearia)
        { 
        using(var conexao = _context.ConexaoPostGreSQL())
            {
                BarbeariasDAO DAO = new BarbeariasDAO(conexao);
                return await DAO.GetBarbeariasAsyncById(idBarbearia);
            }
        
        
        }
    }
}
