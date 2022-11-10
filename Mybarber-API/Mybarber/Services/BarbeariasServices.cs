using Mybarber.Exceptions;
using Mybarber.Exceptions.Tradutor;
using Mybarber.Models;

using Mybarber.Repository;
using Mybarber.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Mybarber.Exceptions.BusinessException;
using static Mybarber.Exceptions.ViewException;

namespace Mybarber.Services
{
    public class BarbeariasServices : IBarbeariasServices
    {

        private readonly IBarbeariasRepository _repo;

        private readonly IGenerallyRepository _generally;

        public BarbeariasServices(IBarbeariasRepository repo, IGenerallyRepository generally)
        {
            this._repo = repo;
            this._generally = generally;
        }

        public async Task<IEnumerable<Barbearias>> GetAllBarbeariasAsync()
        {
            try
            {
                var barbearias = await _repo.GetAllBarbeariasAsync();

                return barbearias;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Barbearias> PatchToggleAgendamentoByBarbearia(Guid idBarbearia)
        {
            try
            {
                var barbearia = await _repo.GetBarbeariasAsyncById(idBarbearia);
                barbearia.Barbeiros = null;
                barbearia.Servicos = null;
                barbearia.Agendamentos = null;
                barbearia.Banner = null;
                barbearia.ServicosBarbeiros = null;
                barbearia.LandingPageImages = null;
                barbearia.Users = null;
                if (barbearia.FuncaoAgendamento)
                {
                    barbearia.FuncaoAgendamento = false;
                    _generally.Update(barbearia);
                }
                else
                {
                    barbearia.FuncaoAgendamento = true;
                    _generally.Update(barbearia);
                }


                if (await _generally.SaveChangesAsync())
                {
                    return barbearia;
                }

                else
                {
                    throw new Exception();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public async Task<Barbearias> PatchToggleAtivoByBarbearia(Guid idBarbearia)
        {
            try
            {
                var barbearia = await _repo.GetBarbeariasAsyncById(idBarbearia);
                barbearia.Barbeiros = null;
                barbearia.Servicos = null;
                barbearia.Agendamentos = null;
                barbearia.Banner = null;
                barbearia.ServicosBarbeiros = null;
                barbearia.LandingPageImages = null;
                barbearia.Users = null;

                if (barbearia.Ativa)
                {
                    barbearia.Ativa = false;
                    _generally.Update(barbearia);
                }
                else
                {
                    barbearia.Ativa = true;
                    _generally.Update(barbearia);
                }


                if (await _generally.SaveChangesAsync())
                {
                    return barbearia;
                }

                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Barbearias> GetBarbeariaAsyncById(Guid idBarbearia)
        {
            try 
            {


                //var barbearia = await _repo.GetBarbeariasAsyncByIdDAO(idBarbearia);

                var barbearia = await _repo.GetBarbeariasAsyncById(idBarbearia);

                return barbearia;

            }catch(Exception)
            {
                throw new Exception();
            }
        }
        public async Task<Barbearias> GetBarbeariaAsyncByRoute(string route)
        {
            try
            {

                var barbearia = await _repo.GetBarbeariasAsyncByRoute(route);

                return barbearia;
                



               

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


        public async Task<bool> PutBarbeariaAsyncById(Guid idBarbearia, Barbearias barbearias)
        {
            try
            {


                var barbeariaFinded = await _repo.GetBarbeariasAsyncById(idBarbearia);
                barbeariaFinded.Barbeiros = null;
                barbeariaFinded.Servicos = null;
                barbeariaFinded.Agendamentos = null;
                barbeariaFinded.Banner = null;
                barbeariaFinded.ServicosBarbeiros = null;
                barbeariaFinded.LandingPageImages = null;
                barbeariaFinded.Users = null;
                barbeariaFinded.NomeBarbearia = barbearias.NomeBarbearia;
                barbeariaFinded.CNPJ = barbearias.CNPJ;
                barbeariaFinded.Ativa = barbearias.Ativa;
                barbeariaFinded.Route = barbearias.Route;
                barbeariaFinded.FuncaoAgendamento = barbearias.FuncaoAgendamento;
                _generally.Update(barbeariaFinded);
                if(await _generally.SaveChangesAsync())
                {
                    return true;
                }

                else
                {
                    return false;
                }
                

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Barbearias> PostBarbeariaAsync(Barbearias barbearias)
        {
            try
            {
                if (ValidaCNPJ.IsCnpj(barbearias.CNPJ) == true || ValidaCPF.IsCpf(barbearias.CNPJ) == true)
                {


                    _generally.Add(barbearias);

                    if (await _generally.SaveChangesAsync())
                    {

                        return barbearias;
                    }
                    else
                    {
                        throw new DbException(TraslateExceptions.NotSaved);
                    }
                }

                else { throw new CNPJException(TraslateExceptions.CNPJInvalido); }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteBarbeariaAsyncById(Guid idBarbearia)
        {
            try
            {
                var barbeariaFinded = await _repo.GetBarbeariasAsyncById(idBarbearia);

                if (barbeariaFinded == null) { throw new Exception(); }


                _generally.Delete(barbeariaFinded);

                if (await _generally.SaveChangesAsync())
                {

                    return "Barbearia Deletado Com sucesso.";
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
