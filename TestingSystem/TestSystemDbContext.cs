using System.Data.Entity;
using TestingSystem.Model;

namespace TestingSystem
{
    class TestSystemDbContext : DbContext
    {
        public TestSystemDbContext() : base()
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<QuizEntry> QuizEntries { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
