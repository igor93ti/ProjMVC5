namespace ProjMVC5.Infra.Data.Migrations
{
    using ProjMVC5.Infra.Data.Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjMVC5Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjMVC5Context context)
        {
        }
    }
}
