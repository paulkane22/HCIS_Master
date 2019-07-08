namespace PJK.PRISM.HCIS_2.DAL.Migrations
{
    using PJK.PRISM.HCIS_2.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PJK.PRISM.HCIS_2.DAL.HCISContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PJK.PRISM.HCIS_2.DAL.HCISContext context)
        {

            context.Persons.AddOrUpdate(p => p.Surname,
                new Person {Surname = "Kane", Forename = "Paul", NoOfDaysLeft = 27 });
        }
    }
}
