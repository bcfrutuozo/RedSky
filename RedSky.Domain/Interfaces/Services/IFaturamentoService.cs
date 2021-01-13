using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IFaturamentoService : IServiceBase<Faturamento>
    {
        IEnumerable<Faturamento> GetFaturamentosPorFatura(int idFatura);
    }
}