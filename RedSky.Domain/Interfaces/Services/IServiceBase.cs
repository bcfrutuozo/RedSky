using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Add(params TEntity[] items);

        IEnumerable<TEntity> Update(params TEntity[] items);

        IEnumerable<TEntity> Delete(params TEntity[] items);

        TEntity Get(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties);

        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] navigationProperties);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties);

        TEntity GetById(int id, params Expression<Func<TEntity, object>>[] navigationProperties);
    }
}