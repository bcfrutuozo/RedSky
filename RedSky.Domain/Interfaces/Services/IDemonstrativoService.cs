using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IDemonstrativoService : IServiceBase<Demonstrativo>
    {
        Demonstrativo GetDemonstrativoById_COPY(int idDemonstrativo);
        IEnumerable<Demonstrativo> GetListDemonstrativoWithIsFaturavelByIdCliente(int idCliente);
        Demonstrativo GetById_DELETE(int id);
        Demonstrativo GetById_CREATEDIT(int id);
        IEnumerable<Demonstrativo> GetListDemonstrativoWithServicoByIdEmpresa_INDEX(int idEmpresa);
        IEnumerable<Demonstrativo> GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(int idEmpresa);
    }
}