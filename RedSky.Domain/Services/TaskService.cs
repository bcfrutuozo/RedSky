using System.Collections.Generic;
using System.Linq;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class TaskService : ServiceBase<Task>, ITaskService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Task> Repository;

        public TaskService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Task> repository) : base(
            contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public Task GetWithCellsById(int idTask)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(t => t.Id == idTask,
                    task => task.TaskCells);
            }
        }
    }
}
