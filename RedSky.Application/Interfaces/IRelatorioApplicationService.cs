using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Application.Interfaces
{
    public interface IRelatorioApplicationService
    {
        #region Demonstrativo

        Demonstrativo AddDemonstrativo(Demonstrativo demonstrativo);

        Demonstrativo GetDemonstrativoById_CREATEEDIT(int idDemonstrativo);

        IEnumerable<Demonstrativo> GetListDemonstrativoWithServicoByIdEmpresa_INDEX(int idEmpresa);

        IEnumerable<Demonstrativo> GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(int idEmpresa);

        IEnumerable<Demonstrativo> GetListDemonstrativoWithIsFaturavelByIdCliente(int idCliente);

        Demonstrativo UpdateDemonstrativo(Demonstrativo demonstrativo);

        Demonstrativo DeleteDemonstrativo(Demonstrativo demonstrativo);

        Demonstrativo CopyDemonstrativoById(int idDemonstrativo);

        #endregion

        #region Servico

        Servico AddServico(Servico servico);

        Servico GetServicoById_CREATEEDIT(int idServico);

        IEnumerable<Servico> GetListServicoByIdDemonstrativo_INDEX(int idDemonstrativo);

        IEnumerable<Servico> GetListServicoByIdFatura(int idFatura);

        Servico UpdateServico(Servico servico);

        Servico DeleteServico(Servico servico);

        IEnumerable<Servico> DeleteServico(IEnumerable<Servico> lstServicos);

        #endregion
    }
}
