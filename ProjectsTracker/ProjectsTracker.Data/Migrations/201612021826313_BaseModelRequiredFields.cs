namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseModelRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Metrics", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PTasks", "CreatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PTasks", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Metrics", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Comments", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Projects", "CreatedOn", c => c.DateTime());
        }
    }
}
