using System;
using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IServicoService : IServiceBase<Servico>
    {
        IEnumerable<Servico> GetListServicoByIdDemonstrativo_INDEX(int idDemonstrativo);
        IEnumerable<Servico> GetListServicoByIdFatura(Int32 idFatura);
        Servico GetServicoById_CREATEEDIT(int id);
    }
}