using System;
using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        IEnumerable<Cliente> GetListClienteByIdEmpresa_INDEX(int idEmpresa);
        Cliente GetClienteById_CREATEUPDATE(int idCliente);
        IEnumerable<Cliente> GetListClienteByIdEmpresa_COMBOBOX(Int32 idEmpresa);
    }
}