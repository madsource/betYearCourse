namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectTasks_cascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TimeReportItems", "PTask_Id", "dbo.PTasks");
            AddForeignKey("dbo.TimeReportItems", "PTask_Id", "dbo.PTasks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeReportItems", "PTask_Id", "dbo.PTasks");
            AddForeignKey("dbo.TimeReportItems", "PTask_Id", "dbo.PTasks", "Id");
        }
    }
}
