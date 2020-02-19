namespace MVC_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalModelAndDTOAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Book_ID = c.Int(nullable: false),
                        Member_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.Book_ID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Member_ID, cascadeDelete: true)
                .Index(t => t.Book_ID)
                .Index(t => t.Member_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Member_ID", "dbo.Members");
            DropForeignKey("dbo.Rentals", "Book_ID", "dbo.Books");
            DropIndex("dbo.Rentals", new[] { "Member_ID" });
            DropIndex("dbo.Rentals", new[] { "Book_ID" });
            DropTable("dbo.Rentals");
        }
    }
}
