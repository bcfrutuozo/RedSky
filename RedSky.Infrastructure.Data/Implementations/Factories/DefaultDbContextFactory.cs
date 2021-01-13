using System;
using System.Data.Entity;
using RedSky.Domain.Interfaces.DbContextScope;

namespace RedSky.Infrastructure.Data.Implementations.Factories
{
    public class DefaultDbContextFactory : IDbContextFactory
    {
        public TDbContext CreateDbContext<TDbContext>() where TDbContext : DbContext
        {
            return Activator.CreateInstance<TDbContext>();
        }
    }
}