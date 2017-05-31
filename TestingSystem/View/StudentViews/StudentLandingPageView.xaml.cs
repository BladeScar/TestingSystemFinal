using System.Windows;
using TestingSystem.Model;

namespace TestingSystem.View.StudentViews
{
    /// <summary>
    /// Interaction logic for StudentLandingPageView.xaml
    /// </summary>
    public partial class StudentLandingPageView : Window
    {
        private int _currentStudentId;

        public StudentLandingPageView(int currentStudentId)
        {
            InitializeComponent();
            this._currentStudentId = currentStudentId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var view = new StudentQuizView(_currentStudentId, 3, true);
            view.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var view = new StudentQuizView(_currentStudentId, 3, false);
            view.Show();
            Close();
        }
    }
}
