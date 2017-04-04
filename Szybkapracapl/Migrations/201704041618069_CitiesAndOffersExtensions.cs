namespace Szybkapracapl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CitiesAndOffersExtensions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Offers", "City_Id", c => c.Int());
            CreateIndex("dbo.Offers", "City_Id");
            AddForeignKey("dbo.Offers", "City_Id", "dbo.Cities", "Id");
            DropColumn("dbo.Offers", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Offers", "City", c => c.String(nullable: false));
            DropForeignKey("dbo.Offers", "City_Id", "dbo.Cities");
            DropIndex("dbo.Offers", new[] { "City_Id" });
            DropColumn("dbo.Offers", "City_Id");
            DropTable("dbo.Cities");
        }
    }
}
