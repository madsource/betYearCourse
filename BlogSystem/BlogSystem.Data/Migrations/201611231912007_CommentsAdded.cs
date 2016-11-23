namespace BlogSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentsAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Text", c => c.String());
            AlterColumn("dbo.Comments", "Author", c => c.String());
        }
    }
}
