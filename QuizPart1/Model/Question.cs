using System.Collections.Generic;

namespace QuizPart1.Model
{
    class Question
    {
        public string Content { get; set; }
        public List<string> Answers { get; set; }
        public int Correct { get; set; }
        public int Chosen { get; set; }

        public Question() { }
        public Question(string c)
        {
            Content = c;
            Correct = 0;
            Answers = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                Answers.Add("");
            }
        }

        public Question(string c, List<string> a, int index, int chosenI)
        {

            Content = c;
            Correct = index;
            Chosen = chosenI;
            Answers = new List<string>();

            foreach (string answer in a)
            {
                this.Answers.Add(answer);
            }

        }

        public override string ToString()
        {
            return Content;
        }
    }
}
