using PJK.PRISM.HCIS_2.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PJK.PRISM.HCIS_2.DAL
{
    class HCISContext : DbContext
    {
        public HCISContext() : base("HCIS_DB")
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Leave> Leave { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

}
