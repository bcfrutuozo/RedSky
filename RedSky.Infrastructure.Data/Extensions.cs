using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RedSky.Infrastructure.Data
{
    public static class Extensions
    {
        public static IQueryable<T> ApplyEagerLoading<T>(this IQueryable<T> source,
            params Expression<Func<T, object>>[] navigationProperties)
        {
            foreach (var join in navigationProperties)
                source = source.Include(join);

            return source;
        }
    }
}