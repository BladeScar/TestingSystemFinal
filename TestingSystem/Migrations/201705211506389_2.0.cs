namespace TestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "GroupId" });
            RenameColumn(table: "dbo.Students", name: "GroupId", newName: "Group_Id");
            AlterColumn("dbo.Students", "Group_Id", c => c.Int());
            CreateIndex("dbo.Students", "Group_Id");
            AddForeignKey("dbo.Students", "Group_Id", "dbo.Groups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Group_Id", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "Group_Id" });
            AlterColumn("dbo.Students", "Group_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Students", name: "Group_Id", newName: "GroupId");
            CreateIndex("dbo.Students", "GroupId");
            AddForeignKey("dbo.Students", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
        }
    }
}
