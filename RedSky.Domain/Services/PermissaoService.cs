using System.Collections.Generic;
using System.Linq;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class PermissaoService : ServiceBase<Permissao>, IPermissaoService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Permissao> Repository;

        public PermissaoService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Permissao> repository) : base(
            contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public IEnumerable<Permissao> GetAllPermissaoByUsuario(string username)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(p => p.UsuarioPermissao.Any(u => u.Usuario.Login == username));
            }
        }
    }
}