using QuizPart1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizPart1.Modules
{
    internal class Quiz
    {
        public string Name { get; set; }
        public List<Question> questions;


        private MainWindow currentWin;
        public Quiz(string n, MainWindow win)
        {
            this.Name = n;
            questions = new List<Question>();
            this.currentWin = win;
        }

        public override string ToString()
        {
            //this.currentWin.NazwaQuizu = "3";
            return this.Name + ", pytań: " + this.questions.Count;
        }
    }
}
