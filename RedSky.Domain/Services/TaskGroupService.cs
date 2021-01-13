using System.Collections.Generic;
using System.Linq;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class TaskGroupService : ServiceBase<TaskGroup>, ITaskGroupService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<TaskGroup> Repository;

        public TaskGroupService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<TaskGroup> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public IEnumerable<TaskGroup> GetListTaskGroupByIdEmpresa(int idEmpresa)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(tg => tg.IdEmpresa == idEmpresa,
                    tg => tg.Columns,
                    tg => tg.Columns.Select(dt => dt.DataType),
                    tg => tg.Columns.Select(t => t.TaskCells),
                    tg => tg.Tasks,
                    tg => tg.Tasks.Select(t => t.TaskCells));
            }
        }

        public TaskGroup GetWithTaskById(int idTaskGroup)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetWithFields(tg => new
                {
                    tg.Id,
                    Tasks = tg.Tasks.Select(task => new
                    {
                        task.Id
                    })
                }, tg => tg.Id == idTaskGroup, tg => tg.Tasks);
            }
        }

        public TaskGroup GetWithColumnsById(int idTaskGroup)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetWithFields(tg => new
                {
                    tg.Id,
                    Columns = tg.Columns.Select(column => new
                    {
                        column.Id
                    })
                }, tg => tg.Id == idTaskGroup, tg => tg.Tasks);
            }
        }
    }
}
