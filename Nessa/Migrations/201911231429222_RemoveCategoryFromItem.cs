namespace Nessa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCategoryFromItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "Category_Id" });
            DropColumn("dbo.Items", "CategoryId");
            DropColumn("dbo.Items", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Category_Id", c => c.Int());
            AddColumn("dbo.Items", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Items", "Category_Id");
            AddForeignKey("dbo.Items", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
