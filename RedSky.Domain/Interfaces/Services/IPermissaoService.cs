using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IPermissaoService : IServiceBase<Permissao>
    {
        IEnumerable<Permissao> GetAllPermissaoByUsuario(string username);
    }
}