namespace Nessa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAllInCategories : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Categories");
        }
        
        public override void Down()
        {
        }
    }
}
