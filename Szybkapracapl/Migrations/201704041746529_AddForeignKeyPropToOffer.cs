namespace Szybkapracapl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropToOffer : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Offers", name: "City_Id", newName: "CityId");
            RenameColumn(table: "dbo.Offers", name: "Employer_Id", newName: "EmployerId");
            RenameIndex(table: "dbo.Offers", name: "IX_Employer_Id", newName: "IX_EmployerId");
            RenameIndex(table: "dbo.Offers", name: "IX_City_Id", newName: "IX_CityId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Offers", name: "IX_CityId", newName: "IX_City_Id");
            RenameIndex(table: "dbo.Offers", name: "IX_EmployerId", newName: "IX_Employer_Id");
            RenameColumn(table: "dbo.Offers", name: "EmployerId", newName: "Employer_Id");
            RenameColumn(table: "dbo.Offers", name: "CityId", newName: "City_Id");
        }
    }
}
