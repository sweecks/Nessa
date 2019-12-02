namespace Nessa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriesFull : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES (N'Въдици')");
            Sql("INSERT INTO Categories (Name) VALUES (N'Рибарски макари')");
            Sql("INSERT INTO Categories (Name) VALUES (N'Корда')");
            Sql("INSERT INTO Categories (Name) VALUES (N'Куки')");
            Sql("INSERT INTO Categories (Name) VALUES (N'Плувки')");
            Sql("INSERT INTO Categories (Name) VALUES (N'Изкуствени')");
            Sql("INSERT INTO Categories (Name) VALUES (N'Части')");
            Sql("INSERT INTO Categories (Name) VALUES (N'Риболовни принадлежности')");
            Sql("INSERT INTO Categories (Name) VALUES (N'Проводници')");
            Sql("INSERT INTO Categories (Name) VALUES (N'Резервни части')");
            Sql("INSERT INTO Categories (Name) VALUES (N'Примамки и основи')");
            Sql("INSERT INTO Categories (Name) VALUES (N'Гребане')");
            Sql("INSERT INTO Categories (Name) VALUES (N'Подводни')");
            Sql("INSERT INTO Categories (Name) VALUES (N'На открито')");
        }
        
        public override void Down()
        {
        }
    }
}
