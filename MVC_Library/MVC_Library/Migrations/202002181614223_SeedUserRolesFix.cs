namespace MVC_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserRolesFix : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6dbbe49b-e8a1-41f0-a8df-25ca0291572a', N'admin@app.com', 0, N'AM5u5RbWFEc0cRgLTso2PWscPwC+ZEqiTVyxeFCPvPpH0QFVpF4IrUDTJ7D4YR3Xww==', N'1f654502-e006-49d5-8429-17b6e5fc933a', NULL, 0, 0, NULL, 1, 0, N'admin@app.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7f9a0dc0-cc11-44b3-843a-4fd14ef9efa6', N'user@app.com', 0, N'ACN8DBlGKb4IIzNcrx38nkWAvA40jx35je0mU+m0hwP4+6nA+Rt9fK5S5ncmY4FY1g==', N'2ef3f87f-567d-4d9a-b6d5-f283dab0076d', NULL, 0, 0, NULL, 1, 0, N'user@app.com')
            ");

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'be2f8d2b-3ae8-4112-870a-c957b5124041', N'CanManageBooks')
            ");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6dbbe49b-e8a1-41f0-a8df-25ca0291572a', N'be2f8d2b-3ae8-4112-870a-c957b5124041')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
