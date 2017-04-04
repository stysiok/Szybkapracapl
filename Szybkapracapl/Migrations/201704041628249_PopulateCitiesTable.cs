namespace Szybkapracapl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCitiesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Cities (Name) VALUES ('Warszawa')");
            Sql("INSERT INTO Cities (Name) VALUES ('Poznañ')");
            Sql("INSERT INTO Cities (Name) VALUES ('Gdañsk')");
            Sql("INSERT INTO Cities (Name) VALUES ('Wroc³aw')");
            Sql("INSERT INTO Cities (Name) VALUES ('Katowice')");

        }
        
        public override void Down()
        {
            Sql("DELETE FROM Cities WHERE Id IN (1, 2, 3, 4, 5)");
        }
    }
}
