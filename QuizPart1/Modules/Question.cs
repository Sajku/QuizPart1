using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPart1.Modules
{
    class Question
    {
        public string Content { get; set; }
        public List<string> Answers { get; set; }
        public int Correct { get; set; }
        public int Chosen { get; set; }

        public Question(string c, List<string> a, int index, int chosenI)
        {

            this.Content = c;
            this.Correct = index;
            this.Chosen = chosenI;
            this.Answers = new List<string>();

            foreach (string answer in a)
            {
                this.Answers.Add(answer);
            }

        }
    }
}
