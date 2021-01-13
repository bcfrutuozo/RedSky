using System.Data.Entity.Migrations;
using RedSky.Infrastructure.Data.Context;

namespace RedSky.Infrastructure.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RedSkyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RedSkyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.SaveChanges();
        }
    }
}