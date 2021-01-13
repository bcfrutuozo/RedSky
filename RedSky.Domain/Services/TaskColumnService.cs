using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class TaskColumnService : ServiceBase<TaskColumn>, ITaskColumnService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<TaskColumn> Repository;

        public TaskColumnService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<TaskColumn> repository) :
            base(contextScopeFactory, repository)
        {
            this.ContextScopeFactory = contextScopeFactory;
            this.Repository = repository;
        }

        public TaskColumn GetWithCellsById(int idTaskColumn)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(tc => tc.Id == idTaskColumn,
                    task => task.TaskCells);
            }
        }

        public TaskColumn GetTaskColumnWithDataTypeById(int idTaskColumn)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(tc => tc.Id == idTaskColumn,
                    dt => dt.DataType);
            }
        }
    }
}
