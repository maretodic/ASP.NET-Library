namespace MVC_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7f31be4f-b332-4e31-97c0-980ac5ece33f', N'admin@app.com', 0, N'AIjd1xhye69Rmx5y4rPXIZV3GsSqplHqU1bWXIx7/JBVqzj/JijzhSHMFmbEeTvafg==', N'8c0c0cb9-dad2-4dc6-8a7e-9a88b15d0f50', NULL, 0, 0, NULL, 1, 0, N'admin@app.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'839788ad-3626-466c-b9cc-ade3d49b3682', N'guest@app.com', 0, N'AEAD7oUH1S0R3V2VH4PqqKF7UCPDfkvCxsuqZh+hr+FofjNwXjZQXzkiUnUxzQZMzg==', N'354ed917-5208-4559-aed5-9e1086eb27c5', NULL, 0, 0, NULL, 1, 0, N'guest@app.com')
            ");

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fec78b03-1b61-4a51-bba1-8361043cbafd', N'CanManageMovies')");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7f31be4f-b332-4e31-97c0-980ac5ece33f', N'fec78b03-1b61-4a51-bba1-8361043cbafd')
            "); 
        }
        
        public override void Down()
        {
        }
    }
}
