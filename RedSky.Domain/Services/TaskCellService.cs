using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class TaskCellService : ServiceBase<TaskCell>, ITaskCellService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<TaskCell> Repository;

        public TaskCellService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<TaskCell> repository)
            : base(contextScopeFactory, repository)
        {
            this.ContextScopeFactory = contextScopeFactory;
            this.Repository = repository;
        }

        public TaskCell GetWithColumnAndDataTypeById(int idTaskCell)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(tc => tc.Id == idTaskCell,
                    tc => tc.TaskColumn,
                    tc => tc.TaskColumn.DataType);
            }
        }
    }
}
