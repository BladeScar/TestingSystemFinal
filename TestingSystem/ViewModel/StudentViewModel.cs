using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Model;

namespace TestingSystem.ViewModel
{
    public static class MyExtensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public class StudentViewModel
    {
        public List<QuizEntry> GetQuizEntries(int numberOfEntries)
        {
            List<QuizEntry> resultList;

            using (var ctx = new TestSystemDbContext())
            {
                resultList = ctx.QuizEntries.ToList();

                foreach (var entry in resultList)
                {
                    entry.Answers = entry.Answers.ToList();
                }

                resultList.Shuffle();
            }

            return resultList.Take(numberOfEntries).ToList();
        }

        public void AddStudentGrade(int studentId, int grade)
        {
            // TODO: Add grades to the system <3
        }
    }
}
