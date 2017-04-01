namespace Szybkapracapl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendingOffer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offers", "Description");
        }
    }
}
