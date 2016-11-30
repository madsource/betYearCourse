namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpectedEndDate_project_madeRequired : DbMigration
    {
        public override void Up()
        {
            Sql("Update dbo.Projects Set ExpectedEndDate = 0 Where ExpectedEndDate Is Null; ");
            AlterColumn("dbo.Projects", "ExpectedEndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "ExpectedEndDate", c => c.DateTime());
        }
    }
}
