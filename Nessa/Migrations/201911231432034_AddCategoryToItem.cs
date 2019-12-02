namespace Nessa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "CategoryId", c => c.Byte(nullable: false));
            AddColumn("dbo.Items", "Category_Id", c => c.Int());
            CreateIndex("dbo.Items", "Category_Id");
            AddForeignKey("dbo.Items", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "Category_Id" });
            DropColumn("dbo.Items", "Category_Id");
            DropColumn("dbo.Items", "CategoryId");
        }
    }
}
