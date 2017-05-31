namespace TestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        QuizEnntryId = c.Int(nullable: false),
                        QuizEntry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizEntries", t => t.QuizEntry_Id)
                .Index(t => t.QuizEntry_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuizEntry_Id", "dbo.QuizEntries");
            DropIndex("dbo.Answers", new[] { "QuizEntry_Id" });
            DropTable("dbo.Answers");
        }
    }
}
