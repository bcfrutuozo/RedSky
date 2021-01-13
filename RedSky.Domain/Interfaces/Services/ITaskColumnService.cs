using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface ITaskColumnService : IServiceBase<TaskColumn>
    {
        TaskColumn GetWithCellsById(int idTaskColumn);
        TaskColumn GetTaskColumnWithDataTypeById(int idTaskColumn);
    }
}
