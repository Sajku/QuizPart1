using QuizPart1.Modules;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;

namespace QuizPart1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Quiz currentQuiz = new Quiz("Pierwszy");

            List<string> lista1 = new List<string>();
            lista1.Add("111a");
            lista1.Add("222a");
            lista1.Add("333a");
            lista1.Add("444a");
            currentQuiz.Questions.Add(new Question("Treść1", lista1, 1, 2));
            lista1.RemoveAt(0);
            lista1.RemoveAt(0);
            lista1.RemoveAt(0);
            lista1.RemoveAt(0);
            lista1.Add("1B");
            lista1.Add("2B");
            lista1.Add("3B");
            lista1.Add("4B");
            currentQuiz.Questions.Add(new Question("TREŚĆ2", lista1, 1, 2));



            string fileName = "dane.json";
            var json = JsonSerializer.Serialize(currentQuiz);
            File.WriteAllText(fileName, json);

        }
    }
}
