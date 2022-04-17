using Mybarber.Models;
using Mybarber.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class ServicosServices : IServicosServices
    {
        private readonly IServicosRepository _repo;

        private readonly IGenerallyRepository _generally;

        public ServicosServices(IServicosRepository repo, IGenerallyRepository generally)
        {
            this._repo = repo;
            this._generally = generally;
        }

        //public async Task<IEnumerable<Servicos>> GetAllServicosAsync()
        //{
        //    try
        //    {
        //        var servicos = await _repo.GetAllServicosAsync();

        //        return servicos;

        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception();
        //    }
        //}

        public async Task<Servicos> GetServicoAsyncById(int idServico)
        {
            try
            {
                var servico = await _repo.GetServicosAsyncById(idServico);

                return servico;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<IEnumerable<Servicos>> GetServicoAsyncByTenant(int idBarbearia)
        {
            try
            {
                var servico = await _repo.GetServicosAsyncByTenant(idBarbearia);

                return servico;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


        public async Task<Servicos> PostServicoAsync(Servicos servicos)
        {
            try
            {
                _generally.Add(servicos);

                if (await _generally.SaveChangesAsync())
                {

                    return servicos;
                }
                else
                {
                    throw new InvalidOperationException("Operação falhou");
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<string> DeleteServicoAsyncById(int idServico)
        {
            try
            {
                var servicoFinded = await _repo.GetServicosAsyncById(idServico);

                if (servicoFinded == null) { throw new Exception(); }


                _generally.Delete(servicoFinded);

                if (await _generally.SaveChangesAsync())
                {

                    return "Servico Deletado Com sucesso.";
                }
                else
                {
                    throw new InvalidOperationException("Operação falhou");
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

  
    }
}
