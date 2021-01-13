using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        void Add(params TEntity[] items);

        void Update(params TEntity[] items);

        void Delete(params TEntity[] items);

        TEntity Get(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] navigationProperties);

        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties);

        TEntity GetById(int id, params Expression<Func<TEntity, object>>[] navigationProperties);

        TEntity GetWithFields(Expression<Func<TEntity, dynamic>> fields = null, Expression<Func<TEntity, bool>> where = null,
            params Expression<Func<TEntity, object>>[] navigationProperties);
      
        IEnumerable<TEntity> GetListWithFields(Expression<Func<TEntity, dynamic>> fields = null, Expression<Func<TEntity, bool>> where = null,
            params Expression<Func<TEntity, object>>[] navigationProperties);

        IEnumerable<TEntity> GetAllWithFields(Expression<Func<TEntity, dynamic>> fields = null,
            params Expression<Func<TEntity, object>>[] navigationProperties);

        TEntity GetByIdWithFields(int id, Expression<Func<TEntity, dynamic>> fields = null,
            params Expression<Func<TEntity, object>>[] navigationProperties);
    }
}