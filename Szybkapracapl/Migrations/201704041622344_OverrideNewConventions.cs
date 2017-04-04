namespace Szybkapracapl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideNewConventions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Offers", "City_Id", "dbo.Cities");
            DropIndex("dbo.Offers", new[] { "City_Id" });
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Offers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Offers", "City_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Offers", "City_Id");
            AddForeignKey("dbo.Offers", "City_Id", "dbo.Cities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "City_Id", "dbo.Cities");
            DropIndex("dbo.Offers", new[] { "City_Id" });
            AlterColumn("dbo.Offers", "City_Id", c => c.Int());
            AlterColumn("dbo.Offers", "Name", c => c.String());
            AlterColumn("dbo.Cities", "Name", c => c.String());
            CreateIndex("dbo.Offers", "City_Id");
            AddForeignKey("dbo.Offers", "City_Id", "dbo.Cities", "Id");
        }
    }
}
