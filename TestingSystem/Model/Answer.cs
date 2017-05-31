using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Model
{
    public class Answer
    {
        public Answer()
        {
        }

        public int Id { get; set; }
        public string Content { get; set; }

        public int QuizEnntryId { get; set; }
        public virtual QuizEntry QuizEntry { get; set; }
    }
}
