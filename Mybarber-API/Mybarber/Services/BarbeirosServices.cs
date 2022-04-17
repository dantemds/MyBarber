using Microsoft.AspNetCore.Identity;
using Mybarber.Exceptions;
using Mybarber.Models;
using Mybarber.Repository;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class BarbeirosServices : IBarbeirosServices
    {
        private readonly IBarbeirosRepository _repo;

        private readonly IGenerallyRepository _generally;

        public BarbeirosServices(IBarbeirosRepository repo, IGenerallyRepository generally)
        {
            this._repo = repo;
            this._generally = generally;
        }

        //public async Task<IEnumerable<Barbeiros>> GetAllBarbeirosAsync()
        //{
        //    try
        //    {
        //        var barbeiros = await _repo.GetAllBarbeirosAsync();

        //        return barbeiros;

        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception();
        //    }
        //}

        public async Task<Barbeiros> GetBarbeiroAsyncById(int idBarbeiro)
        {
            try
            {
                var barbeiro = await _repo.GetBarbeirosAsyncById(idBarbeiro);

                return barbeiro;

            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
            public async Task<IEnumerable<Barbeiros>> GetBarbeiroAsyncByTenant(int idBarbearia)
            {
                try
                {
                    var barbeiro = await _repo.GetBarbeirosAsyncByTenant(idBarbearia);

                    return barbeiro;

                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }

    



        public async Task<Barbeiros> PostBarbeiroAsync(Barbeiros barbeiros)
        {
            try
            {
                _generally.Add(barbeiros);

                if (await _generally.SaveChangesAsync())
                {
                   
                    return barbeiros;
                }
                else
                {
                    throw new InvalidOperationException("Operação falhou");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> DeleteBarbeiroAsyncById(int idBarbeiro)
        {
            try
            {
                var barbeiroFinded = await _repo.GetBarbeirosAsyncById(idBarbeiro);

                


                if (barbeiroFinded == null) { throw new ViewException("Barbeiro.Not.Found"); }


                _generally.Delete(barbeiroFinded);

                if (await _generally.SaveChangesAsync())
                {

                    return "Barbeiro Deletado Com sucesso.";
                }
                else
                {
                    throw new ViewException("Operation.Failed");
                }
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);

            }
        }
        public async Task<bool> UpdateBarbeiroAsyncById(int idBarbeiro)
        {

            try
            {
                var barbeiroFinded = await _repo.GetBarbeirosAsyncById(idBarbeiro);

                if (barbeiroFinded == null) throw new ViewException("Barbeiro.Not.Found");

                _generally.Update(barbeiroFinded);

                if (await _generally.SaveChangesAsync())
                {
                    return true;
                }
                else
                {
                    throw new ViewException("Operation.Failed");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
