namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PTAdmin_role_add : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N\'b7c00a38-fd44-4ecc-be8c-303adfdf456f\', N\'PTAdministrator\')\r\n");
        }

        public override void Down()
        {
        }
    }
}
