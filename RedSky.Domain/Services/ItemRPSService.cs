using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class ItemRPSService : ServiceBase<ItemRPS>, IItemRPSService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<ItemRPS> Repository;

        public ItemRPSService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<ItemRPS> repository) : base(
            contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }
    }
}