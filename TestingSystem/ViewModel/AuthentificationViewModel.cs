using System.ComponentModel;
using System.Linq;
using System.Windows;
using TestingSystem.Model;
using TestingSystem.View.StudentViews;

namespace TestingSystem.ViewModel
{
    public class AuthentificationViewModel : INotifyPropertyChanged
    {
        public AuthentificationViewModel()
        {       
        }

        public enum EUserStatus
        {
            eStudent,
            eTeacher,
            eInvalid
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public EUserStatus LogIn(string username, string password)
        {
            return IsRegisteredUser(username, password);
        }
    
        public EUserStatus Register(string username, string password, bool isStudent)
        {
            bool isUsernameTaken = IsUsernameTaken(username);
            EUserStatus userStatus = EUserStatus.eInvalid;

            if (!isUsernameTaken)
            {
                using (var ctx = new TestSystemDbContext())
                {
                    if (isStudent)
                    {
                        Student stud = new Student() { Username = username, Password = password };
                        ctx.Students.Add(stud);
                        userStatus = EUserStatus.eStudent;
                    }
                    else
                    {
                        Teacher teacher = new Teacher() { Username = username, Password = password };
                        ctx.Teachers.Add(teacher);
                        userStatus = EUserStatus.eTeacher;
                    }

                    ctx.SaveChanges();
                }
            }

            return userStatus;
        }

        private EUserStatus IsRegisteredUser(string username, string password)
        {
            EUserStatus userStatus = EUserStatus.eInvalid;

            using (var ctx = new TestSystemDbContext())
            {
                var studentsList = ctx.Students.ToList();
                var teachersList = ctx.Teachers.ToList();

                foreach (var student in studentsList)
                {
                    if (student.Username == username && student.Password == password)
                    {
                        userStatus = EUserStatus.eStudent;
                        break;
                    }
                }

                if (userStatus == EUserStatus.eInvalid)
                {
                    foreach (var teacher in teachersList)
                    {
                        if (teacher.Username == username && teacher.Password == password)
                        {
                            userStatus = EUserStatus.eTeacher;
                            break;
                        }
                    }
                }
            }

            return userStatus;
        }

        private bool IsUsernameTaken(string username)
        {
            bool isUsernameTaken = false;

            using (var ctx = new TestSystemDbContext())
            {
                var studentsList = ctx.Students.ToList();
                var teachersList = ctx.Teachers.ToList();

                foreach (var student in studentsList)
                {
                    if (student.Username == username)
                    {
                        isUsernameTaken = true;
                        break;
                    }
                }

                if (!isUsernameTaken)
                {
                    foreach (var teacher in teachersList)
                    {
                        if (teacher.Username == username)
                        {
                            isUsernameTaken = true;
                            break;
                        }
                    }
                }
            }

            return isUsernameTaken;
        }
    }
}
