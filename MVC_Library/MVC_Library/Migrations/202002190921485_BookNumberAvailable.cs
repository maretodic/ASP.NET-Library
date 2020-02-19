namespace MVC_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookNumberAvailable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Books SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
