namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Project_PTask_Comment_Metric_initModelsStructure : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Projects", name: "AuthorId", newName: "OwnerId");
            RenameIndex(table: "dbo.Projects", name: "IX_AuthorId", newName: "IX_OwnerId");
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        CreatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Metrics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Revenue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CashInput = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HoursSpend = c.Single(nullable: false),
                        CreatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        ReportedBy_Id = c.String(maxLength: 128),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReportedBy_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.ReportedBy_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.PTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Title = c.String(nullable: false),
                        EstimatedHours = c.Single(nullable: false),
                        ProgressPercent = c.Single(nullable: false),
                        CreatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Author_Id = c.String(nullable: false, maxLength: 128),
                        Owner_Id = c.String(maxLength: 128),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Project_Id);
            
            AddColumn("dbo.Projects", "ExpectedEndDate", c => c.DateTime());
            AddColumn("dbo.Projects", "DateFinished", c => c.DateTime());
            AddColumn("dbo.Projects", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Projects", "EstimatedBudget", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Projects", "ClientName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PTasks", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.PTasks", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PTasks", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Metrics", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Metrics", "ReportedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PTasks", new[] { "Project_Id" });
            DropIndex("dbo.PTasks", new[] { "Owner_Id" });
            DropIndex("dbo.PTasks", new[] { "Author_Id" });
            DropIndex("dbo.Metrics", new[] { "Project_Id" });
            DropIndex("dbo.Metrics", new[] { "ReportedBy_Id" });
            DropIndex("dbo.Comments", new[] { "Project_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropColumn("dbo.Projects", "ClientName");
            DropColumn("dbo.Projects", "EstimatedBudget");
            DropColumn("dbo.Projects", "isActive");
            DropColumn("dbo.Projects", "DateFinished");
            DropColumn("dbo.Projects", "ExpectedEndDate");
            DropTable("dbo.PTasks");
            DropTable("dbo.Metrics");
            DropTable("dbo.Comments");
            RenameIndex(table: "dbo.Projects", name: "IX_OwnerId", newName: "IX_AuthorId");
            RenameColumn(table: "dbo.Projects", name: "OwnerId", newName: "AuthorId");
        }
    }
}
