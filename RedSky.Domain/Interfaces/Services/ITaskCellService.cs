using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface ITaskCellService : IServiceBase<TaskCell>
    {
        TaskCell GetWithColumnAndDataTypeById(int idTaskCell);
    }
}
