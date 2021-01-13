using System.Collections.Generic;
using System.Linq;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class DemonstrativoService : ServiceBase<Demonstrativo>, IDemonstrativoService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Demonstrativo> Repository;

        public DemonstrativoService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Demonstrativo> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public Demonstrativo GetDemonstrativoById_COPY(int idDemonstrativo)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(d => d.Id == idDemonstrativo,
                    d => d.Servicos);
            }
        }

        public IEnumerable<Demonstrativo> GetListDemonstrativoWithIsFaturavelByIdCliente(int idCliente)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(d => d.IdCliente == idCliente && d.IsFaturavel);
            }
        }

        public Demonstrativo GetById_DELETE(int id)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(d => d.Id == id, d => d.Servicos);
            }
        }

        public Demonstrativo GetById_CREATEDIT(int id)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(id, dem => dem.Cliente,
                    dem => dem.Cliente.Cidade,
                    dem => dem.Cliente.Cidade.Estado,
                    dem => dem.Cliente.TipoBairro,
                    dem => dem.Cliente.TipoLogradouro);
            }
        }

        public IEnumerable<Demonstrativo> GetListDemonstrativoWithServicoByIdEmpresa_INDEX(int idEmpresa)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(dem => dem.IdEmpresa == idEmpresa, dem => dem.Cliente,
                    dem => dem.Cliente.Cidade,
                    dem => dem.Cliente.Cidade.Estado,
                    dem => dem.Cliente.TipoBairro,
                    dem => dem.Cliente.TipoLogradouro,
                    dem => dem.Servicos,
                    dem => dem.Servicos.Select(ser => ser.ConexaoBanco),
                    dem => dem.Servicos.Select(ser => ser.ConexaoBanco.DBProvider),
                    dem => dem.Servicos.Select(ser => ser.Unidade));
            }
        }

        public IEnumerable<Demonstrativo> GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(int idEmpresa)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(dem => dem.IdEmpresa == idEmpresa, dem => dem.Cliente,
                    dem => dem.Cliente.Cidade,
                    dem => dem.Cliente.Cidade.Estado,
                    dem => dem.Cliente.TipoBairro,
                    dem => dem.Cliente.TipoLogradouro);
            }
        }
    }
}