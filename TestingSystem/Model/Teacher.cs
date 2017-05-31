using System.Collections.Generic;

namespace TestingSystem.Model
{
    public class Teacher
    {
        private ICollection<Group> _groups;
        private ICollection<QuizEntry> _entries;

        public Teacher()
        {
            _groups = new List<Group>();
            _entries = new List<QuizEntry>();

        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsLoggedIn { get; set; }
        public virtual ICollection<Group> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        public virtual ICollection<QuizEntry> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }
    }
}
