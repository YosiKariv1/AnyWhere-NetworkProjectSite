namespace AnyWhere____Network_Project_Website.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AnyWhere___Network_Project_WebSite.Dal.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AnyWhere___Network_Project_WebSite.Dal.UsersDal";
        }

        protected override void Seed(AnyWhere___Network_Project_WebSite.Dal.DB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
