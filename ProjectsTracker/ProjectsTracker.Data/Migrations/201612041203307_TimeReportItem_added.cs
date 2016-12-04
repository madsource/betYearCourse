namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeReportItem_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeReportItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportedOn = c.DateTime(nullable: false),
                        HoursSpend = c.Single(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        PTask_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PTasks", t => t.PTask_Id)
                .Index(t => t.PTask_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeReportItems", "PTask_Id", "dbo.PTasks");
            DropIndex("dbo.TimeReportItems", new[] { "PTask_Id" });
            DropTable("dbo.TimeReportItems");
        }
    }
}
