using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class UtilizacaoService : ServiceBase<Utilizacao>, IUtilizacaoService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Utilizacao> Repository;

        public UtilizacaoService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Utilizacao> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }
    }
}