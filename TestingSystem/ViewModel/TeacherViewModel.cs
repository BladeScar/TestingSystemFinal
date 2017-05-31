using System.Collections.Generic;
using TestingSystem.Model;

namespace TestingSystem.ViewModel
{
    public class TeacherViewModel
    {
        public enum EQuestionState
        {
            eNew,
            ePresent,
            eInvalid
        }

        public TeacherViewModel()
        {

        }

        public EQuestionState AddNewQuestion(string question, List<string> answers, int currentTeacherId)
        {
            using (var ctx = new TestSystemDbContext())
            {
                Teacher currentTeacher = null;
                foreach (var teacher in ctx.Teachers)
                {
                    if (teacher.Id == currentTeacherId)
                    {
                        currentTeacher = teacher;
                    }
                }

                foreach (var entry in ctx.QuizEntries)
                {
                    if (question == entry.Question && currentTeacher.Id == entry.TeacherId)
                    {
                        return EQuestionState.ePresent;
                    }
                }

                var newEntry = new QuizEntry();
                newEntry.Question = question;

                foreach (var ans in answers)
                {
                    var newAns = new Answer();
                    newAns.Content = ans;

                    newEntry.Answers.Add(newAns);
                }

                newEntry.TeacherId = currentTeacher.Id;
                newEntry.Teacher = currentTeacher;
                ctx.QuizEntries.Add(newEntry);
                ctx.SaveChanges();
            }

            return EQuestionState.eNew;
        }
    }
}
