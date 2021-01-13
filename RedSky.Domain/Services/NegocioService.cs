using System.Collections.Generic;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class NegocioService : ServiceBase<Negocio>, INegocioService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Negocio> Repository;

        public NegocioService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Negocio> repository) : base(
            contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public IEnumerable<Negocio> GetAllPorUsuario(int idUsuarioResponsavel)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(ng => ng.IdUsuarioResponsavel == idUsuarioResponsavel);
            }
        }
    }
}