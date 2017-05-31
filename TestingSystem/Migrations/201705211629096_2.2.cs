namespace TestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.QuizEntries", "RightAnswerIndex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuizEntries", "RightAnswerIndex", c => c.Int(nullable: false));
        }
    }
}
