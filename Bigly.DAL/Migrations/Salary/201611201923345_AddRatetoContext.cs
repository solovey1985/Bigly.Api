namespace Bigly.DAL.Migrations.Trip
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatetoContext : DbMigration
    {
        public override void Up()
        {

            AddForeignKey("dbo.Employees", "RateId", "dbo.Rates", "Id", false);
        }

        public override void Down()
        {
            
            DropForeignKey("dbo.Employees", "RateId", "dbo.Rates");
            
        }
    }
}
