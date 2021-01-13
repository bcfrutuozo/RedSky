using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class AtividadeService : ServiceBase<Atividade>, IAtividadeService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Atividade> Repository;

        public AtividadeService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Atividade> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public Atividade GetById(int id)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(id,
                    atv => atv.Incidencia,
                    atv => atv.Operacao,
                    atv => atv.ItensServico,
                    atv => atv.Tributacao,
                    atv => atv.Utilizacao);
            }
        }

        public IEnumerable<Atividade> GetAll()
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetAll(
                    atv => atv.Incidencia,
                    atv => atv.Operacao,
                    atv => atv.ItensServico,
                    atv => atv.Tributacao,
                    atv => atv.Utilizacao);
            }
        }

        public IEnumerable<Atividade> GetListAtividadeByIdEmpresa(int idEmpresa,
            params Expression<Func<Atividade, object>>[] navigationProperties)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(atv => atv.Empresas.Any(e => e.Id == idEmpresa), 
                    atv => atv.Incidencia,
                    atv => atv.Operacao,
                    atv => atv.ItensServico,
                    atv => atv.Tributacao,
                    atv => atv.Utilizacao);
            }
        }
    }
}