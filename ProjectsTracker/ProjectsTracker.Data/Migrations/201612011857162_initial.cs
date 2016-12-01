namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(),
                        ExpectedEndDate = c.DateTime(nullable: false),
                        DateFinished = c.DateTime(),
                        isActive = c.Boolean(nullable: false),
                        EstimatedBudget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientName = c.String(nullable: false),
                        CreatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Owner_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id, cascadeDelete: true)
                .Index(t => t.Owner_Id);
            
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PTasks", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.PTasks", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PTasks", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Metrics", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Metrics", "ReportedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PTasks", new[] { "Project_Id" });
            DropIndex("dbo.PTasks", new[] { "Owner_Id" });
            DropIndex("dbo.PTasks", new[] { "Author_Id" });
            DropIndex("dbo.Metrics", new[] { "Project_Id" });
            DropIndex("dbo.Metrics", new[] { "ReportedBy_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "Project_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Projects", new[] { "Owner_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PTasks");
            DropTable("dbo.Metrics");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
            DropTable("dbo.Projects");
        }
    }
}
