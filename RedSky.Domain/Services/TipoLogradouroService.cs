using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class TipoLogradouroService : ServiceBase<TipoLogradouro>, ITipoLogradouroService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<TipoLogradouro> Repository;

        public TipoLogradouroService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<TipoLogradouro> repository) :
            base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }
    }
}