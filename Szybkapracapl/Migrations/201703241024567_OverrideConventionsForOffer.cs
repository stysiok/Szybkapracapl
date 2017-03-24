namespace Szybkapracapl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForOffer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Offers", "Employer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Offers", new[] { "Employer_Id" });
            AlterColumn("dbo.Offers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Offers", "Employer_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Offers", "Employer_Id");
            AddForeignKey("dbo.Offers", "Employer_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "Employer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Offers", new[] { "Employer_Id" });
            AlterColumn("dbo.Offers", "Employer_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Offers", "City", c => c.String());
            CreateIndex("dbo.Offers", "Employer_Id");
            AddForeignKey("dbo.Offers", "Employer_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
