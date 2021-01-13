using System.Collections.Generic;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class FaturamentoService : ServiceBase<Faturamento>, IFaturamentoService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Faturamento> Repository;

        public FaturamentoService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Faturamento> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public IEnumerable<Faturamento> GetFaturamentosPorFatura(int idFatura)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(fat => fat.IdFatura == idFatura);
            }
        }
    }
}