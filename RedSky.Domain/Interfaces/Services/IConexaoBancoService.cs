using System;
using System.Collections.Generic;
using System.Data;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IConexaoBancoService : IServiceBase<ConexaoBanco>
    {
        IEnumerable<ConexaoBanco> GetListConexaoBancoByIdEmpresa(Int32 idEmpresa);
        ConexaoBanco GetConexaoBancoByIdEmpresa_Nome(Int32 idEmpresa, String nome);
    }
}