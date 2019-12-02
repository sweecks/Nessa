namespace Nessa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCategoryToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Price", c => c.String());
            AddColumn("dbo.Items", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "CategoryId");
            AddForeignKey("dbo.Items", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropColumn("dbo.Items", "CategoryId");
            DropColumn("dbo.Items", "Price");
        }
    }
}
