using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Infrastructure.Data.Context;

namespace RedSky.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        private readonly IAmbientDbContextLocator _database;
        private readonly IMapper _mapper;

        public RepositoryBase(IAmbientDbContextLocator contextLocator, IMapper mapper)
        {
            _database = contextLocator;
            _mapper = mapper;
        }

        public void Add(params TEntity[] items)
        {
            foreach (var entity in items)
                _database.Get<RedSkyContext>().Entry(entity).State = EntityState.Added;
        }

        public void Update(params TEntity[] items)
        {
            foreach (var entity in items)
                _database.Get<RedSkyContext>().Entry(entity).State = EntityState.Modified;
        }

        public void Delete(params TEntity[] items)
        {
            foreach (var entity in items)
                _database.Get<RedSkyContext>().Entry(entity).State = EntityState.Deleted;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return _database.Get<RedSkyContext>().Set<TEntity>().ApplyEagerLoading(navigationProperties).AsNoTracking()
                .Where(where).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return _database.Get<RedSkyContext>().Set<TEntity>().ApplyEagerLoading(navigationProperties).Where(where)
                .AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return _database.Get<RedSkyContext>().Set<TEntity>().ApplyEagerLoading(navigationProperties).AsNoTracking()
                .ToList();
        }

        public TEntity GetById(int id, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return _database.Get<RedSkyContext>().Set<TEntity>().ApplyEagerLoading(navigationProperties).AsNoTracking()
                .Single(ett => ett.Id == id);
        }

        public TEntity GetWithFields(Expression<Func<TEntity, dynamic>> fields = null,
            Expression<Func<TEntity, bool>> where = null,
            params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> dbQuery = _database.Get<RedSkyContext>().Set<TEntity>()
                .ApplyEagerLoading(navigationProperties).AsNoTracking();

            if (where != null)
                dbQuery = dbQuery.Where(where);

            if (fields != null)
                return _mapper.Map<TEntity>(dbQuery.Select(fields).FirstOrDefault());

            return dbQuery.FirstOrDefault();
        }

        public IEnumerable<TEntity> GetListWithFields(Expression<Func<TEntity, dynamic>> fields = null,
            Expression<Func<TEntity, bool>> where = null,
            params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> dbQuery = _database.Get<RedSkyContext>().Set<TEntity>()
                .ApplyEagerLoading(navigationProperties).AsNoTracking();

            if (where != null)
                dbQuery = dbQuery.Where(where);

            if (fields != null)
                return _mapper.Map<IEnumerable<TEntity>>(dbQuery.Select(fields).ToList());

            return dbQuery.ToList();
        }

        public IEnumerable<TEntity> GetAllWithFields(Expression<Func<TEntity, dynamic>> fields = null,
            params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> dbQuery = _database.Get<RedSkyContext>().Set<TEntity>()
                .ApplyEagerLoading(navigationProperties).AsNoTracking();

            if (fields != null)
                return _mapper.Map<IEnumerable<TEntity>>(dbQuery.Select(fields).ToList());

            return dbQuery.ToList();
        }

        public TEntity GetByIdWithFields(int id, Expression<Func<TEntity, dynamic>> fields = null,
            params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> dbQuery = _database.Get<RedSkyContext>().Set<TEntity>()
                .ApplyEagerLoading(navigationProperties).AsNoTracking();

            if (fields != null)
                return _mapper.Map<TEntity>(dbQuery.Where(ett => ett.Id == id).Select(fields).FirstOrDefault());

            return dbQuery.Single(ett => ett.Id == id);
        }
    }
}