namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeReportItem_deletedReportedOn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TimeReportItems", "ReportedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeReportItems", "ReportedOn", c => c.DateTime(nullable: false));
        }
    }
}
