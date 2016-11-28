namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignPTAdmin_toUserRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N\'fb37458a-88b8-42ad-973e-ee442ed2a751\', N\'b7c00a38-fd44-4ecc-be8c-303adfdf456f\')");
        }

        public override void Down()
        {
        }
    }
}
