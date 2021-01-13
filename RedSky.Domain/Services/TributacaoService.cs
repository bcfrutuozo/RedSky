using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class TributacaoService : ServiceBase<Tributacao>, ITributacaoService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Tributacao> Repository;

        public TributacaoService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Tributacao> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }
    }
}