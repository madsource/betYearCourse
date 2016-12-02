namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseModelAdded_UpdateOn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.Comments", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.Metrics", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.PTasks", "UpdatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PTasks", "UpdatedOn");
            DropColumn("dbo.Metrics", "UpdatedOn");
            DropColumn("dbo.Comments", "UpdatedOn");
            DropColumn("dbo.Projects", "UpdatedOn");
        }
    }
}
