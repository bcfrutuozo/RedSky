using System;
using System.Collections.Generic;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class ProjetoService : ServiceBase<Projeto>, IProjetoService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Projeto> Repository;

        public ProjetoService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Projeto> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public IEnumerable<Projeto> GetListProjetoByIdEmpresa_INDEX(Int32 idEmpresa)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetListWithFields(p => new
                {
                    p.Id,
                    p.Identificacao,
                    p.DataInicio,
                    p.DataFinal,
                    StatusProjeto = new
                    {
                        p.StatusProjeto.Descricao
                    }
                },p => p.IdEmpresa == idEmpresa);
            }
        }

        public Projeto GetProjetoById(Int32 id)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(id);
            }
        }
    }
}
