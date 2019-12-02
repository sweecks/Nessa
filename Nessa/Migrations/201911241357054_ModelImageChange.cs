namespace Nessa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelImageChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            DropColumn("dbo.Items", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "ImagePath", c => c.String());
            DropForeignKey("dbo.Images", "ItemId", "dbo.Items");
            DropIndex("dbo.Images", new[] { "ItemId" });
            DropTable("dbo.Images");
        }
    }
}
