namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin_User : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N\'fb37458a-88b8-42ad-973e-ee442ed2a751\', N\'admin@projectstracker.bg\', 0, N\'AG7yzxxqBUVpjt91LZQmi6tD1bXKRq6tE9dK0E/A5nraohgDIFcyHoFqEoK5UR13cQ==\', N\'fbc6f6b6-e581-45d5-9509-4d8822a83c0d\', NULL, 0, 0, NULL, 1, 0, N\'admin@projectstracker.bg\', N\'ApplicationUser\')\r\n");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N\'b7c00a38-fd44-4ecc-be8c-303adfdf456f\', N\'PTAdministrator\')\r\n");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N\'fb37458a-88b8-42ad-973e-ee442ed2a751\', N\'b7c00a38-fd44-4ecc-be8c-303adfdf456f\')");

        }
        
        public override void Down()
        {
        }
    }
}
