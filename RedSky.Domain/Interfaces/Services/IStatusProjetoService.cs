using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IStatusProjetoService : IServiceBase<StatusProjeto>
    {
        IEnumerable<StatusProjeto> GetAllStatusProjeto_COMBOBOX();
    }
}
