namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PTAdministrator_user_add : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N\'fb37458a-88b8-42ad-973e-ee442ed2a751\', N\'admin@projectstracker.bg\', 0, N\'AG7yzxxqBUVpjt91LZQmi6tD1bXKRq6tE9dK0E/A5nraohgDIFcyHoFqEoK5UR13cQ==\', N\'fbc6f6b6-e581-45d5-9509-4d8822a83c0d\', NULL, 0, 0, NULL, 1, 0, N\'admin@projectstracker.bg\', N\'ApplicationUser\')\r\n");  
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator], [FirstName], [LastName]) VALUES (N\'fb37458a-88b8-42ad-973e-ee442ed2a751\', N\'admin@projectstracker.bg\', 0, N\'AG7yzxxqBUVpjt91LZQmi6tD1bXKRq6tE9dK0E/A5nraohgDIFcyHoFqEoK5UR13cQ==\', N\'fbc6f6b6-e581-45d5-9509-4d8822a83c0d\', NULL, 0, 0, NULL, 1, 0, N\'admin@projectstracker.bg\', N\'ApplicationUser\', N\'Admin\', N\'\')");
        }
        
        public override void Down()
        {
        }
    }
}
