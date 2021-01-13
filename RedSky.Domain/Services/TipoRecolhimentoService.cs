using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class TipoRecolhimentoService : ServiceBase<TipoRecolhimento>, ITipoRecolhimentoService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<TipoRecolhimento> Repository;

        public TipoRecolhimentoService(IDbContextScopeFactory contextScopeFactory,
            IRepositoryBase<TipoRecolhimento> repository) : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }
    }
}