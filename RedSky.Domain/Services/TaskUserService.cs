using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class TaskUserService : ServiceBase<TaskUser>, ITaskUserService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<TaskUser> Repository;

        public TaskUserService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<TaskUser> repository) : base(
            contextScopeFactory, repository)
        {
            this.ContextScopeFactory = contextScopeFactory;
            this.Repository = repository;
        }
    }
}
