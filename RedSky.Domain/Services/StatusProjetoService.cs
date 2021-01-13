using System.Collections.Generic;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class StatusProjetoService : ServiceBase<StatusProjeto>, IStatusProjetoService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<StatusProjeto> Repository;

        public StatusProjetoService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<StatusProjeto> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public IEnumerable<StatusProjeto> GetAllStatusProjeto_COMBOBOX()
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetAll();
            }
        }
    }
}
