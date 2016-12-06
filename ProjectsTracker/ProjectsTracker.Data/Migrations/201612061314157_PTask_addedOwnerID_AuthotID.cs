namespace ProjectsTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PTask_addedOwnerID_AuthotID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PTasks", name: "Author_Id", newName: "AuthorId");
            RenameColumn(table: "dbo.PTasks", name: "Owner_Id", newName: "OwnerId");
            RenameIndex(table: "dbo.PTasks", name: "IX_Author_Id", newName: "IX_AuthorId");
            RenameIndex(table: "dbo.PTasks", name: "IX_Owner_Id", newName: "IX_OwnerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PTasks", name: "IX_OwnerId", newName: "IX_Owner_Id");
            RenameIndex(table: "dbo.PTasks", name: "IX_AuthorId", newName: "IX_Author_Id");
            RenameColumn(table: "dbo.PTasks", name: "OwnerId", newName: "Owner_Id");
            RenameColumn(table: "dbo.PTasks", name: "AuthorId", newName: "Author_Id");
        }
    }
}
