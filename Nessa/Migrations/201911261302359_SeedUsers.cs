namespace Nessa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a83f63a2-4824-46d4-a37f-0df49f7fb90c', N'admin@nessa.bg', 0, N'AHY9Bk8l8+zkOj9K6bc0X2BnnHaM2fyQNiZG4TsAOHcaJBYayt5uY/MkRxG0CVEOGA==', N'2aa7465d-5928-489b-b8f9-c4217547d69c', NULL, 0, 0, NULL, 1, 0, N'admin@nessa.bg')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1f832746-1ea3-477b-a1b4-abc0fba1f2d8', N'Admin')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a83f63a2-4824-46d4-a37f-0df49f7fb90c', N'1f832746-1ea3-477b-a1b4-abc0fba1f2d8')
");
        }
        
        public override void Down()
        {
        }
    }
}
