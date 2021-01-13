using System.Collections.Generic;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Cidade> Repository;

        public CidadeService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Cidade> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public IEnumerable<Cidade> GetByEstado(int idEstado)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(c => c.IdEstado == idEstado);
            }
        }
    }
}