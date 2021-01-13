using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface INegocioService : IServiceBase<Negocio>
    {
        IEnumerable<Negocio> GetAllPorUsuario(int idUsuarioResponsavel);
    }
}