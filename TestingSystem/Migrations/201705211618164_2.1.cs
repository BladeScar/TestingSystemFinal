namespace TestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuizEntries", "RightAnswerIndex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuizEntries", "RightAnswerIndex");
        }
    }
}
