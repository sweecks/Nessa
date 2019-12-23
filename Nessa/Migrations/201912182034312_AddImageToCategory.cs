namespace Nessa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ImagePath");
        }
    }
}
