namespace Nessa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES ('Въдици')");
            Sql("INSERT INTO Categories (Name) VALUES ('Рибарски макари')");
        }
        
        public override void Down()
        {
        }
    }
}
