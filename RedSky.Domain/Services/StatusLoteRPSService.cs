using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class StatusLoteRPSService : ServiceBase<StatusLoteRPS>, IStatusLoteRPSService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<StatusLoteRPS> Repository;

        public StatusLoteRPSService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<StatusLoteRPS> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }
    }
}