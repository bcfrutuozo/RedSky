using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class DeducaoRPSService : ServiceBase<DeducaoRPS>, IDeducaoRPSService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<DeducaoRPS> Repository;

        public DeducaoRPSService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<DeducaoRPS> repository) : base(
            contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }
    }
}