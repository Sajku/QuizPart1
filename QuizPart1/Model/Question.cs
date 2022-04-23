using System.Collections.Generic;

namespace QuizPart1.Model
{
    class Question
    {
        public string Content { get; set; }
        public List<string> Answers { get; set; }
        public List<int> Correct { get; set; }
        public int Chosen { get; set; }

        public Question() { }
        public Question(string c)
        {
            Content = c;
            Correct = new List<int>();
            Answers = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                Answers.Add("");
            }
        }

        public Question(string c, List<string> a, List<int> indexes, int chosenI)
        {
            Content = c;
            Correct = new List<int>();
            Chosen = chosenI;
            foreach (int answer in indexes)
            {
                Correct.Add(answer);
            }

            Answers = new List<string>();
            foreach (string answer in a)
            {
                Answers.Add(answer);
            }
        }

        public override string ToString()
        {
            return Content;
        }
    }
}
