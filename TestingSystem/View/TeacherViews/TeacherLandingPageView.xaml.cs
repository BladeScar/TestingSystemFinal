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

namespace TestingSystem.View.TeacherViews
{
    /// <summary>
    /// Interaction logic for TeacherLandingPageView.xaml
    /// </summary>
    public partial class TeacherLandingPageView : Window
    {
        private int _currentTeacherId;

        public TeacherLandingPageView(int currentTeacherId)
        {
            InitializeComponent();
            this._currentTeacherId = currentTeacherId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateQuestionView view = new CreateQuestionView(_currentTeacherId);
            view.Show();
            Close();
        }
    }
}
