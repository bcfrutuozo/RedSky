using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IProjetoService : IServiceBase<Projeto>
    {
        IEnumerable<Projeto> GetListProjetoByIdEmpresa_INDEX(int idEmpresa);
        Projeto GetProjetoById(int id);
    }
}
