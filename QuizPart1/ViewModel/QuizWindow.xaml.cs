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
using QuizPart1.Model;

namespace QuizPart1.ViewModel
{
    /// <summary>
    /// Logika interakcji dla klasy QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        public QuizWindow(object currentQuiz)
        {
            InitializeComponent();
            Quiz c = (Quiz)currentQuiz;
            DataContext = new QuizViewModel(c);
            Title = "Quiz - " + c.Name;
        }
    }
}
