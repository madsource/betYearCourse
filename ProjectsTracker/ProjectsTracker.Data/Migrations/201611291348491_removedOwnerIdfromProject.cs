namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedOwnerIdfromProject : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Projects", name: "OwnerId", newName: "Owner_Id");
            RenameIndex(table: "dbo.Projects", name: "IX_OwnerId", newName: "IX_Owner_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Projects", name: "IX_Owner_Id", newName: "IX_OwnerId");
            RenameColumn(table: "dbo.Projects", name: "Owner_Id", newName: "OwnerId");
        }
    }
}
