namespace Bigly.DAL.Migrations.User
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rates", t => t.RateId, cascadeDelete: true)
                .Index(t => t.RateId);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeePosition = c.String(),
                        AmountPerHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Period_Since = c.DateTime(nullable: false),
                        Period_Till = c.DateTime(nullable: false),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "RateId", "dbo.Rates");
            DropIndex("dbo.Salaries", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "RateId" });
            DropTable("dbo.Salaries");
            DropTable("dbo.Rates");
            DropTable("dbo.Employees");
        }
    }
}
