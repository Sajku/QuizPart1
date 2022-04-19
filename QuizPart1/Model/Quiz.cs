using QuizPart1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizPart1.Model
{
    class Quiz
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz(string n)
        {
            this.Name = n;
            Questions = new List<Question>();
        }

        public override string ToString()
        {
            //this.currentWin.NazwaQuizu = "3";
            return this.Name + ", pytań: " + this.Questions.Count;
        }

    }
}
