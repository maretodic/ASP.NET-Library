namespace MVC_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreAndMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(ID, Name, SignUpFee, DurationInMonths) VALUES (1, 'Pay as you Go', 10, 0)");
            Sql("INSERT INTO MembershipTypes(ID, Name, SignUpFee, DurationInMonths) VALUES (2, 'Monthly', 25, 1)");
            Sql("INSERT INTO MembershipTypes(ID, Name, SignUpFee, DurationInMonths) VALUES (3, 'Quarterly', 60, 3)");
            Sql("INSERT INTO MembershipTypes(ID, Name, SignUpFee, DurationInMonths) VALUES (4, 'Yearly', 200, 12)");

            Sql("INSERT INTO Genres(Name) VALUES ('Action and Adventure')");
            Sql("INSERT INTO Genres(Name) VALUES ('Comic Book or Graphic Novel')");
            Sql("INSERT INTO Genres(Name) VALUES ('Fantasy')");
            Sql("INSERT INTO Genres(Name) VALUES ('Classics')");
            Sql("INSERT INTO Genres(Name) VALUES ('Poetry')");
            Sql("INSERT INTO Genres(Name) VALUES ('True Crime')");
        }
        
        public override void Down()
        {
        }
    }
}
