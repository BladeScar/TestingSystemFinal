using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestingSystem.Model;
using TestingSystem.View.StudentViews;
using TestingSystem.ViewModel;

namespace TestingSystem.View
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : Window
    {
        public LogInView()
        {
            InitializeComponent();
        }

        private void LogIn_CLick(object sender, RoutedEventArgs e)
        {
            AuthentificationViewModel.EUserStatus userStatus = (DataContext as AuthentificationViewModel).LogIn(usrText.Text, passText.Password);
            Window view;

            switch (userStatus)
            {
                case AuthentificationViewModel.EUserStatus.eStudent:
                    Student currentStudent = null;
                    using (var ctx = new TestSystemDbContext())
                    {
                        var studentsList = ctx.Students.ToList();

                        foreach (var student in studentsList)
                        {
                            if (student.Username == usrText.Text)
                            {
                                currentStudent = student;
                                break;
                            }
                        }
                    }

                    view = new StudentLandingPageView(currentStudent.Id);
                    break;
                case AuthentificationViewModel.EUserStatus.eTeacher:
                    Teacher currentTeacher = null;
                    using (var ctx = new TestSystemDbContext())
                    {
                        var teacherList = ctx.Teachers.ToList();

                        foreach (var teacher in teacherList)
                        {
                            if (teacher.Username == usrText.Text)
                            {
                                currentTeacher = teacher;
                                break;
                            }
                        }
                    }

                    view = new TeacherViews.TeacherLandingPageView(currentTeacher.Id);
                    break;
                case AuthentificationViewModel.EUserStatus.eInvalid:
                default:
                    MessageBox.Show("Invalid username or password!\nPlease register to log in the system!", "Invalid user", MessageBoxButton.OK);
                    view = new RegisterView(RegisterView.EPrevView.eLogIn);
                    break;
            }

            view.Show();
            Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterView view = new RegisterView(RegisterView.EPrevView.eLogIn);
            view.Show();
            Close();
        }
    }
}
