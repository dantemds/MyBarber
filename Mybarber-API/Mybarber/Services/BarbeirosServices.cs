using Microsoft.AspNetCore.Identity;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.Exceptions;
using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Persistences;
using Mybarber.Repositories;
using Mybarber.Repository;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class BarbeirosServices : IBarbeirosServices
    {
        private readonly IBarbeirosRepository _repo;
        private readonly IServicosRepository _servicosRepository;
        private readonly IGenerallyRepository _generally;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHash _hash;
        private readonly IUsersRepository _usersRepository;
        private readonly IBarbeariasRepository _barbeariasRepository;

        public BarbeirosServices(IBarbeirosRepository repo, IGenerallyRepository generally, IUnitOfWork unitOfWork, IHash hash, IUsersRepository usersRepository, IServicosRepository servicosRepository, IBarbeariasRepository barbeariasRepository)
        {
            this._servicosRepository = servicosRepository;
            this._repo = repo;
            this._barbeariasRepository = barbeariasRepository;
            this._generally = generally;
            this._unitOfWork = unitOfWork;
            this._usersRepository = usersRepository;
            this._hash = hash;
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

        public async Task<Barbeiros> GetBarbeiroAsyncById(Guid idBarbeiro)
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
        public async Task<IEnumerable<Barbeiros>> GetBarbeiroAsyncByTenant(Guid idBarbearia)
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

        public async Task<bool> PostTodosBarbeiroTodosServicos(Guid tenant)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                var barbearia = await _barbeariasRepository.GetBarbeariasAsyncById(tenant);
                var servicos = barbearia.Servicos;
                var barbeiros = await _repo.GetBarbeirosAsyncByTenant(tenant);
                foreach (var barbeiro in barbeiros)
                {
                    var contem = false;
                    foreach (var servico in servicos)
                    {
                        foreach (var barbeiroServico in servico.ServicosBarbeiros)
                        {
                            if (barbeiroServico.BarbeirosId == barbeiro.IdBarbeiro)
                            {
                                contem = true;
                            }
                        }
                        if (contem)
                        {
                            contem = false;
                            continue;
                        }
                        else
                        {
                            ServicosBarbeiros servicosBarbeiros = new ServicosBarbeiros(servico.IdServico, barbeiro.IdBarbeiro, tenant);
                            _generally.Add(servicosBarbeiros);
                        }
                    }
                }
                if (await _generally.SaveChangesAsync())
                {
                    await _unitOfWork.CommitTransaction();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBack();
                throw ex;
            }

        }

        public async Task<Barbeiros> PostBarbeiroTodosServicosAsync(BarbeirosRequestDto barbeirosRequestDto)
        {
            try
            {
               await _unitOfWork.BeginTransaction();
                var usuarioFinded = await _usersRepository.GetUserAsyncByEmail(barbeirosRequestDto.Email);
                if (usuarioFinded != null) throw new Exception();
                var passwordHash = _hash.CriptografarSenha(barbeirosRequestDto.Password);


                var usuario = new Users
                {
                    UserName = barbeirosRequestDto.NameBarbeiro,
                    Email = barbeirosRequestDto.Email,
                    Password = passwordHash,

                    BarbeariasId = barbeirosRequestDto.BarbeariasId
                };

                _generally.Add(usuario);

                Barbeiros barbeiro = new Barbeiros
                {
                    NameBarbeiro = barbeirosRequestDto.NameBarbeiro,
                    BarbeariasId = barbeirosRequestDto.BarbeariasId,

                };

                barbeiro.UsersId = usuario.IdUser;
                 _generally.Add(barbeiro);

                
                Servicos[] servicos = await _servicosRepository.GetServicosAsyncByTenant(barbeirosRequestDto.BarbeariasId);
                foreach (Servicos servico in servicos)
                {
                    ServicosBarbeiros servicosBarbeiros = new ServicosBarbeiros(servico.IdServico, barbeiro.IdBarbeiro, barbeiro.BarbeariasId);

                    _generally.Add(servicosBarbeiros);
                }
                if (await _generally.SaveChangesAsync())
                {
                    await _unitOfWork.CommitTransaction();

                }
                var barbeiroResult = await _repo.GetBarbeirosAsyncById(barbeiro.IdBarbeiro);
                if (barbeiroResult != null)
                {
                    return barbeiroResult;
                } 
                else
                {
                    throw new Exception();
                }


            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBack();
                throw ex;
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
        public async Task<string> DeleteBarbeiroAsyncById(Guid idBarbeiro)
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
        public async Task<bool> UpdateBarbeiroAsyncById(Guid idBarbeiro)
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
