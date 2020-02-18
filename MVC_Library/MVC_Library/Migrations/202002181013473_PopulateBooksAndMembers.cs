namespace MVC_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBooksAndMembers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Books(Author, Title, GenreID, ISBN, NumberInStock, NumberAvailable) VALUES ('Alan Moore', 'Watchmen', 2, '9781401248192', 15, 15)");
            Sql("INSERT INTO Books(Author, Title, GenreID, ISBN, NumberInStock, NumberAvailable) VALUES ('Frank Miller', 'Batman Year One', 2, '9781401207526', 13, 13)");
            Sql("INSERT INTO Books(Author, Title, GenreID, ISBN, NumberInStock, NumberAvailable) VALUES ('Jacques Prevert', 'Paroles', 5, '9782070367627', 12, 12)");
            Sql("INSERT INTO Books(Author, Title, GenreID, ISBN, NumberInStock, NumberAvailable) VALUES ('Roberto Saviano', 'Gommorah', 6, '9781509843886', 7, 7)");
            Sql("INSERT INTO Books(Author, Title, GenreID, ISBN, NumberInStock, NumberAvailable) VALUES ('Ivo Andric', 'The Bridge over Drina', 4, '9780048230171', 7, 7)");
            Sql("INSERT INTO Books(Author, Title, GenreID, ISBN, NumberInStock, NumberAvailable) VALUES ('Jack London', 'White Feng', 1, '9780141321110', 9, 9)");
            Sql("INSERT INTO Books(Author, Title, GenreID, ISBN, NumberInStock, NumberAvailable) VALUES ('J R R Tolkien', 'The Hobbit', 3, '9780395071229', 14, 14)");
            Sql("INSERT INTO Books(Author, Title, GenreID, ISBN, NumberInStock, NumberAvailable) VALUES ('Haruki Murakami', 'Norwegian Wood', 3, '9780099448822', 11, 11)");

            Sql("INSERT INTO Members(Name, BirthDate, IsSubscribedToNewsletter, MembershipTypeID) VALUES('Adam Kovic', '02/20/1985', 0, 1)");
            Sql("INSERT INTO Members(Name, BirthDate, IsSubscribedToNewsletter, MembershipTypeID) VALUES('Bruce Greene', '08/12/1981', 0, 2)");
            Sql("INSERT INTO Members(Name, BirthDate, IsSubscribedToNewsletter, MembershipTypeID) VALUES('James Willems', '04/06/1984', 1, 3)");
            Sql("INSERT INTO Members(Name, BirthDate, IsSubscribedToNewsletter, MembershipTypeID) VALUES('Elyse Willems', '05/03/1986', 1, 4)");
        }
        
        public override void Down()
        {
        }
    }
}
