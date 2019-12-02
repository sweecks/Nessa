namespace Nessa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireThePriceAndDescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "Price", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Price", c => c.String());
            AlterColumn("dbo.Items", "Description", c => c.String());
        }
    }
}
