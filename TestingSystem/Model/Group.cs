using System.Collections.Generic;

namespace TestingSystem.Model
{
    public class Group
    {
        private ICollection<Student> _students;

        public Group()
        {
            _students = new List<Student>();
        }

        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

    }
}
