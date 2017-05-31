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
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public enum EPrevView
        {
            eLogIn,
            eMain
        }

        private bool isStudent = false;
        public EPrevView PrevView { get; set; }

        public RegisterView(EPrevView prevView = EPrevView.eMain)
        {
            InitializeComponent();
            this.PrevView = prevView;
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            var userStatus = (DataContext as AuthentificationViewModel).Register(usrTxt.Text, passTxt.Password, isStudent);
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
                            if (student.Username == usrTxt.Text)
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
                            if (teacher.Username == usrTxt.Text)
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
                    MessageBox.Show("The desired username is already taken!\nPlease try again!", "Invalid user", MessageBoxButton.OK);
                    view = new RegisterView();
                    break;
            }

            view.Show();
            Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Window view;

            switch (PrevView)
            {
                case EPrevView.eLogIn:
                    view = new LogInView();
                    break;
                case EPrevView.eMain:
                default:
                    view = new MainWindow();
                    break;
            }

            view.Show();
            Close();
        }

        private void StudentBtn_Checked(object sender, RoutedEventArgs e)
        {
            isStudent = true;
        }

        private void TeacherBtn_Checked(object sender, RoutedEventArgs e)
        {
            isStudent = false;
        }
    }
}
