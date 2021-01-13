using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface ITaskGroupService : IServiceBase<TaskGroup>
    {
        IEnumerable<TaskGroup> GetListTaskGroupByIdEmpresa(int idEmpresa);

        TaskGroup GetWithTaskById(int idTaskGroup);
        TaskGroup GetWithColumnsById(int idTaskGroup);
    }
}
