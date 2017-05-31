using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TestingSystem.Model;
using TestingSystem.ViewModel;

namespace TestingSystem.View.StudentViews
{
    /// <summary>
    /// Interaction logic for StudentQuizView.xaml
    /// </summary>
    public partial class StudentQuizView : Window
    {
        private int _currentStudentId;
        private bool _isTimedQuiz;
        private int _currentQuestionIndex;
        private List<QuizEntry> quizEntries;
        private string _currrentSelectedAnswer;
        private string _currentCorrectAnswer;

        private int _totalQustionCount;
        private int _correctQuestionsCount;

        private string currentTime;
        private DispatcherTimer dt;
        private Stopwatch stopWatch;


        public StudentQuizView(int currentStudentId, int totalQuestionCount = 3, bool isTimedQuiz = false)
        {
            InitializeComponent();
            this._currentStudentId = currentStudentId;
            this._isTimedQuiz = isTimedQuiz;
            this._currentCorrectAnswer = String.Empty;
            this._totalQustionCount = totalQuestionCount;

            if (this._isTimedQuiz)
            {
                timer.Visibility = Visibility.Visible;
                dt = new DispatcherTimer();
                stopWatch = new Stopwatch();
                currentTime = string.Empty;

                SystemEvents.SessionEnding += new SessionEndingEventHandler(SystemEvents_SessionEnding);
                SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
                dt.Tick += new EventHandler(dt_Tick);
                dt.Interval = new TimeSpan(0, 0, 0, 0, 100);

                stopWatch.Start();
                dt.Start();
            }
            else
            {
                timer.Visibility = Visibility.Hidden;
                timer.Height = 0.0;
            }

            this.quizEntries = (DataContext as StudentViewModel).GetQuizEntries(_totalQustionCount);
            _currentQuestionIndex = 0;
            DisplayCurrentQuestion();
        }

        private void DisplayCurrentQuestion()
        {
            quizPanel.Children.Clear();
            QuizEntry currentEntry = quizEntries[_currentQuestionIndex];
            List<Answer> answers = currentEntry.Answers.ToList();

            _currentCorrectAnswer = answers[0].Content;

            TextBlock question = new TextBlock();
            question.VerticalAlignment = VerticalAlignment.Center;
            question.HorizontalAlignment = HorizontalAlignment.Center;
            question.FontSize = 18;
            question.Text = currentEntry.Question;
            quizPanel.Children.Add(question);

            if (answers.Count == 1)
            {
                var answer = new TextBox();
                answer.Text = String.Empty;
                answer.Height = 50.0;
                quizPanel.Children.Add(answer);
            }
            else if (answers.Count > 1)
            {
                answers.Shuffle();

                foreach (var ans in currentEntry.Answers)
                {
                    var radioButton = new RadioButton();
                    radioButton.Content = ans.Content;
                    radioButton.HorizontalAlignment = HorizontalAlignment.Center;
                    radioButton.VerticalAlignment = VerticalAlignment.Center;
                    radioButton.FontSize = 14;
                    radioButton.GotFocus += button_GotFocus;
                    quizPanel.Children.Add(radioButton);
                }
            }

        }

        private void dt_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan ts = stopWatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);

                timer.Content = currentTime;

                if (currentTime == "00:45:00")
                {
                    stopWatch.Stop();
                    dt.Stop();
                    MessageBox.Show("!!!Time is up!!!", "Quiz end", MessageBoxButton.OK);
                }
            }
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                // ...
                case SessionSwitchReason.SessionLock:
                    if (stopWatch.IsRunning)
                        stopWatch.Stop();
                    break;
                case SessionSwitchReason.SessionUnlock:
                    stopWatch.Start();
                    dt.Start();
                    break;
                case SessionSwitchReason.SessionLogoff:
                    MessageBox.Show("Total amount of time the system logged on:" + timer.Content);
                    break;
                    // ...
            }
        }

        private void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            if (Environment.HasShutdownStarted)
            {
                MessageBox.Show("Total amount of time the system logged on:" + timer.Content);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var view = new StudentLandingPageView(_currentStudentId);
            view.Show();
            Close();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (quizEntries[_currentQuestionIndex].Answers.Count == 1)
            {
                _currrentSelectedAnswer = (quizPanel.Children[1] as TextBox).Text;
            }

            if (CheckAnswer())
            {
                _correctQuestionsCount++;
            }

            quizEntries.RemoveAt(_currentQuestionIndex);
            _currentQuestionIndex = 0;

            if (quizEntries.Count > 0)
            {
                DisplayCurrentQuestion();
            }
            else
            {
                double percent = (double)(_correctQuestionsCount) / (double)(_totalQustionCount);
                int score = 2;

                if (percent >= 0.5 && percent < 0.6)
                {
                    score = 3;
                }
                else if (percent >= 0.6 && percent < 0.7)
                {
                    score = 4;
                }
                else if (percent >= 0.7 && percent < 0.8)
                {
                    score = 5;
                }
                else if (percent >= 0.8)
                {
                    score = 6;
                }

                string message = String.Format("You scored {0}%. This means that your score is {1}.", percent * 100, score);
                (DataContext as StudentViewModel).AddStudentGrade(_currentStudentId, score);
                MessageBox.Show(message, "Quiz completed", MessageBoxButton.OK);

            }

        }

        private bool CheckAnswer()
        {
            return _currrentSelectedAnswer == _currentCorrectAnswer;
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_currentQuestionIndex < quizEntries.Count - 1)
            {
                _currentQuestionIndex++;
                DisplayCurrentQuestion();
            }
        }

        private void prevBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_currentQuestionIndex > 0)
            {
                _currentQuestionIndex--;
                DisplayCurrentQuestion();
            }
        }

        private void button_GotFocus(object sender, RoutedEventArgs e)
        {
            _currrentSelectedAnswer = (sender as RadioButton).Content.ToString();
        }
    }
}
