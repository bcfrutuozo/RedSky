using System;
using System.Collections.Generic;
using System.Linq;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class EmpresaService : ServiceBase<Empresa>, IEmpresaService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Empresa> Repository;

        public EmpresaService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Empresa> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public Empresa GetEmpresaByIdentificacao(string identificacao)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(e => e.Identificacao.Equals(identificacao));
            }
        }

        public Empresa GetEmpresaByIdUsuario(Int32 idUsuario)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(e => e.Usuarios.Any(u => u.Id == idUsuario));
            }
        }

        public Empresa GetEmpresaByLoginUsuario(String loginUsuario)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(e => e.Usuarios.Any(u => u.Login.Equals(loginUsuario)));
            }
        }

        public IEnumerable<Empresa> GetListEmpresaForGenericData()
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetAllWithFields(e => new
                {
                    e.Id,
                    e.Identificacao
                });
            }
        }
    }
}