using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface ICidadeService : IServiceBase<Cidade>
    {
        IEnumerable<Cidade> GetByEstado(int idEstado);
    }
}