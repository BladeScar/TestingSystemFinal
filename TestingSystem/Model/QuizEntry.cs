using System.Collections.Generic;

namespace TestingSystem.Model
{
    public class QuizEntry
    {
        private ICollection<Answer> _answers;

        public QuizEntry()
        {
            _answers = new List<Answer>();
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public virtual ICollection<Answer> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }
    }
}
