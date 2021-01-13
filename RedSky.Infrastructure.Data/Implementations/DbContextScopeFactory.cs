using System;
using System.Data;
using RedSky.Domain.Enums.DbContextScope;
using RedSky.Domain.Interfaces.DbContextScope;

namespace RedSky.Infrastructure.Data.Implementations
{
    public class DbContextScopeFactory : IDbContextScopeFactory
    {
        private readonly IDbContextFactory _dbContextFactory;

        // Default constructor for improved support for dependency injection containers that don't support default parameters.
        public DbContextScopeFactory()
            : this(null)
        {
        }

        public DbContextScopeFactory(IDbContextFactory dbContextFactory = null)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IDbContextScope Create(DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting)
        {
            return new DbContextScope(
                joiningOption,
                false,
                null,
                _dbContextFactory);
        }

        public IDbContextReadOnlyScope CreateReadOnly(
            DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting)
        {
            return new DbContextReadOnlyScope(
                joiningOption,
                null,
                _dbContextFactory);
        }

        public IDbContextScope CreateWithTransaction(IsolationLevel isolationLevel)
        {
            return new DbContextScope(
                DbContextScopeOption.ForceCreateNew,
                false,
                isolationLevel,
                _dbContextFactory);
        }

        public IDbContextReadOnlyScope CreateReadOnlyWithTransaction(IsolationLevel isolationLevel)
        {
            return new DbContextReadOnlyScope(
                DbContextScopeOption.ForceCreateNew,
                isolationLevel,
                _dbContextFactory);
        }

        public IDisposable SuppressAmbientContext()
        {
            return new AmbientContextSuppressor();
        }
    }
}