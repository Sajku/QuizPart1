using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPart1.Modules
{
    internal class Question
    {
        public string Content { get; set; }
        public List<string> Answers;
        public int Correct { get; set; }
        public int Chosen { get; set; }

        public Question(string c, string[] a, int index)
        {

            this.Content = c;
            this.Correct = index;

            foreach (string answer in a)
            {
                this.Answers.Add(answer);
            }

        }


    }
}
