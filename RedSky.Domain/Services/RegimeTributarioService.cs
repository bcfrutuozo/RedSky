using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class RegimeTributarioService : ServiceBase<RegimeTributario>, IRegimeTributarioService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<RegimeTributario> Repository;

        public RegimeTributarioService(IDbContextScopeFactory contextScopeFactory,
            IRepositoryBase<RegimeTributario> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }
    }
}