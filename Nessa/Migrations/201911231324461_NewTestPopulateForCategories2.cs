namespace Nessa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTestPopulateForCategories2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES (N'Въдици')");
        }
        
        public override void Down()
        {
        }
    }
}
