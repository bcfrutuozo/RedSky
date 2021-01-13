using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class UsuarioPermissaoService : ServiceBase<UsuarioPermissao>, IUsuarioPermissaoService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<UsuarioPermissao> Repository;

        public UsuarioPermissaoService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<UsuarioPermissao> repository) : base(contextScopeFactory, repository)
        {
            this.ContextScopeFactory = contextScopeFactory;
            this.Repository = repository;
        }
    }
}
