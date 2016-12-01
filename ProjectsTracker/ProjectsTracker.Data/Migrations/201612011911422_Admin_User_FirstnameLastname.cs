namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin_User_FirstnameLastname : DbMigration
    {
        public override void Up()
        {
            Sql("Update [dbo].[AspNetUsers] SET [FirstName] = 'Admin' WHERE [Id] = N\'fb37458a-88b8-42ad-973e-ee442ed2a751\'");
        }
        
        public override void Down()
        {
        }
    }
}
