using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using TestingSystem.ViewModel;

namespace TestingSystem.View.TeacherViews
{
    /// <summary>
    /// Interaction logic for CreateQuestionView.xaml
    /// </summary>
    public partial class CreateQuestionView : Window
    {
        private int _currentTeacherId;

        public CreateQuestionView(int currentTeacherId)
        {
            InitializeComponent();
            this._currentTeacherId = currentTeacherId;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var question = qstTxt.Text;
            var isValidQuestion = String.IsNullOrEmpty(question);
            var answers = ansTxt.Text.Split(',').ToList();

            if (!isValidQuestion && answers.Count > 0)
            {
                switch ((DataContext as TeacherViewModel).AddNewQuestion(question.Trim(), answers, _currentTeacherId))
                {
                    case TeacherViewModel.EQuestionState.eNew:
                        MessageBox.Show("The question has been saved!", "Question save", MessageBoxButton.OK);
                        break;
                    case TeacherViewModel.EQuestionState.ePresent:
                        MessageBox.Show("You have already submited this question!", "Question duplication", MessageBoxButton.OK);
                        break;
                    case TeacherViewModel.EQuestionState.eInvalid:
                    default:
                        Debug.Assert(false, "Invalid state for adding qustions");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid question or answer!\nPlease check if everything is correct!", "Invalid question/answer", MessageBoxButton.OK);
            }
        }

        private void qstTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            qstTxt.Text = "";
        }

        private void ansTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            ansTxt.Text = "";
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            var view = new TeacherLandingPageView(_currentTeacherId);
            view.Show();
            Close();
        }
    }
}
