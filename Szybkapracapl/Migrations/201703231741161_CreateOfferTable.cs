namespace Szybkapracapl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateOfferTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Sallary = c.Double(nullable: false),
                        City = c.String(),
                        Employer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Employer_Id)
                .Index(t => t.Employer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "Employer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Offers", new[] { "Employer_Id" });
            DropTable("dbo.Offers");
        }
    }
}
