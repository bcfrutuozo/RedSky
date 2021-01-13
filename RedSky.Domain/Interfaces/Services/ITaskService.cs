using System.Collections;
using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface ITaskService : IServiceBase<Task>
    {
        Task GetWithCellsById(int idTask);
    }
}
