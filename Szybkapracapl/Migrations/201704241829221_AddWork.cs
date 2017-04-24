namespace Szybkapracapl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        OfferId = c.Int(nullable: false),
                        EmployerId = c.String(nullable: false, maxLength: 128),
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.OfferId, t.EmployerId, t.EmployeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployerId)
                .ForeignKey("dbo.Offers", t => t.OfferId)
                .Index(t => t.OfferId)
                .Index(t => t.EmployerId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.Works", "EmployerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Works", "EmployeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Works", new[] { "EmployeeId" });
            DropIndex("dbo.Works", new[] { "EmployerId" });
            DropIndex("dbo.Works", new[] { "OfferId" });
            DropTable("dbo.Works");
        }
    }
}
