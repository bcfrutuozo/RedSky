using System;
using System.Collections.Generic;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class ConexaoBancoService : ServiceBase<ConexaoBanco>, IConexaoBancoService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<ConexaoBanco> Repository;

        public ConexaoBancoService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<ConexaoBanco> repository) :
            base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public IEnumerable<ConexaoBanco> GetListConexaoBancoByIdEmpresa(Int32 idEmpresa)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(cb => cb.IdEmpresa == idEmpresa);
            }
        }

        public ConexaoBanco GetConexaoBancoByIdEmpresa_Nome(Int32 idEmpresa, String nome)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(cb => cb.IdEmpresa == idEmpresa && cb.Nome.Equals(nome));
            }
        }
    }
}