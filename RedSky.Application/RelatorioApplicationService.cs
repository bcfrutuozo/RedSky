using System;
using System.Collections.Generic;
using System.Linq;
using RedSky.Application.Interfaces;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Application
{
    public class RelatorioApplicationService : IRelatorioApplicationService
    {
        private readonly IDemonstrativoService DemonstrativoService;
        private readonly IServicoService ServicoService;

        public RelatorioApplicationService(
            IDemonstrativoService demonstrativoService,
            IServicoService servicoService)
        {
            this.DemonstrativoService = demonstrativoService;
            this.ServicoService = servicoService;
        }

        #region Demonstrativo

        public Demonstrativo AddDemonstrativo(Demonstrativo demonstrativo)
        {
            return DemonstrativoService.Add(demonstrativo).First();
        }

        public Demonstrativo GetDemonstrativoById_CREATEEDIT(int idDemonstrativo)
        {
            return DemonstrativoService.GetById_CREATEDIT(idDemonstrativo);
        }

        public IEnumerable<Demonstrativo> GetListDemonstrativoWithServicoByIdEmpresa_INDEX(int idEmpresa)
        {
            return DemonstrativoService.GetListDemonstrativoWithServicoByIdEmpresa_INDEX(idEmpresa);
        }

        public IEnumerable<Demonstrativo> GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(int idEmpresa)
        {
            return DemonstrativoService.GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(idEmpresa);
        }

        public IEnumerable<Demonstrativo> GetListDemonstrativoWithIsFaturavelByIdCliente(int idCliente)
        {
            return DemonstrativoService.GetListDemonstrativoWithIsFaturavelByIdCliente(idCliente);
        }

        public Demonstrativo UpdateDemonstrativo(Demonstrativo demonstrativo)
        {
            if (demonstrativo.Servicos.Count > 0)
            {
                foreach (var svc in demonstrativo.Servicos)
                {
                    if (svc.Id == 0)
                        ServicoService.Update(svc);
                    else
                        ServicoService.Add(svc);
                }
            }

            // Limpa as propriedades de eager loading para efetuar a atualização.
            demonstrativo.Cliente = null;
            demonstrativo.Servicos = null;

            return DemonstrativoService.Update(demonstrativo).First();
        }

        public Demonstrativo DeleteDemonstrativo(Demonstrativo demonstrativo)
        {
            var d = DemonstrativoService.GetById_DELETE(demonstrativo.Id);

            // Limpa todos os serviços para poder excluir o demonstrativo.
            if (d.Servicos.Count > 0)
            {
                ServicoService.Delete(d.Servicos.ToArray());

                // Limpa as propriedades de eager loading para efetuar a remoção.
                d.Servicos = null;
            }
            
            return DemonstrativoService.Delete(demonstrativo).First();
        }

        public Demonstrativo CopyDemonstrativoById(int idDemonstrativo)
        {
            var d = DemonstrativoService.GetDemonstrativoById_COPY(idDemonstrativo);

            // Change the name and null the ids for recursive insertion.
            d.Nome =  $@"Copy from {d.Nome}";
            d.Id = 0;
            foreach (var svc in d.Servicos)
                svc.Id = svc.IdDemonstrativo = 0;
            
            return DemonstrativoService.Add(d).First();
        }

        #endregion

        #region Servico

        public Servico AddServico(Servico servico)
        {
            return ServicoService.Add(servico).First();
        }

        public Servico GetServicoById_CREATEEDIT(int id)
        {
            return ServicoService.GetServicoById_CREATEEDIT(id);
        }

        public IEnumerable<Servico> GetListServicoByIdDemonstrativo_INDEX(int idDemonstrativo)
        {
            return ServicoService.GetListServicoByIdDemonstrativo_INDEX(idDemonstrativo);
        }

        public IEnumerable<Servico> GetListServicoByIdFatura(Int32 idFatura)
        {
            return ServicoService.GetListServicoByIdFatura(idFatura);
        }

        public Servico UpdateServico(Servico servico)
        {
            return ServicoService.Update(servico).First();
        }

        public Servico DeleteServico(Servico servico)
        {
            return ServicoService.Delete(servico).First();
        }

        public IEnumerable<Servico> DeleteServico(IEnumerable<Servico> lstServicos)
        {
            return ServicoService.Delete(lstServicos.ToArray());
        }

        #endregion
    }
}
