namespace PJK.PRISM.HCIS_2.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leave",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaveTypeId = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        NoWorkingDays = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Forename = c.String(),
                        NoOfDaysLeft = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leave", "PersonId", "dbo.Person");
            DropIndex("dbo.Leave", new[] { "PersonId" });
            DropTable("dbo.Person");
            DropTable("dbo.Leave");
        }
    }
}
