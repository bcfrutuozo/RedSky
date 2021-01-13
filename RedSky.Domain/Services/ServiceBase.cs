using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class, IEntity
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<TEntity> Repository;

        public ServiceBase(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<TEntity> repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public IEnumerable<TEntity> Add(params TEntity[] itens)
        {
            using (var dbContextScope = ContextScopeFactory.Create())
            {
                Repository.Add(itens);
                dbContextScope.SaveChanges();
                dbContextScope.RefreshEntitiesInParentScope(itens);
                return itens;
            }
        }
        
        public IEnumerable<TEntity> Update(params TEntity[] itens)
        {
            using (var dbContextScope = ContextScopeFactory.Create())
            {
                Repository.Update(itens);
                dbContextScope.SaveChanges();
                dbContextScope.RefreshEntitiesInParentScope(itens);
                return itens;
            }
        }

        public IEnumerable<TEntity> Delete(params TEntity[] itens)
        {
            using (var dbContextScope = ContextScopeFactory.Create())
            {
                Repository.Delete(itens);
                dbContextScope.SaveChanges();
                dbContextScope.RefreshEntitiesInParentScope(itens);
                return itens;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(where, navigationProperties);
            }
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(where, navigationProperties);
            }
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetAll(navigationProperties);
            }
        }

        public TEntity GetById(int id, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(id, navigationProperties);
            }
        }
    }
}