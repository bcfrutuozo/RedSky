using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IEmpresaService : IServiceBase<Empresa>
    {
        Empresa GetEmpresaByIdentificacao(string identificacao);
        Empresa GetEmpresaByIdUsuario(int idUsuario);
        Empresa GetEmpresaByLoginUsuario(string loginUsuario);
        IEnumerable<Empresa> GetListEmpresaForGenericData();
    }
}