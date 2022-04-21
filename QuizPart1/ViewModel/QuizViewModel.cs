using QuizPart1.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace QuizPart1.ViewModel
{
    class QuizViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Quiz currentQuiz;
        private int chosenQuestionIndex;
        private bool readyToSave;
        public QuizViewModel(Quiz currentQuiz1)
        {
            QuestionList = new ObservableCollection<Question>();

            foreach (Question o in currentQuiz1.Questions)
            {
                QuestionList.Add(o);
            }

            currentQuiz = currentQuiz1;
            chosenQuestionIndex = -1;
            readyToSave = false;

            currentContent = "";
            currentAnswer0 = "";
            currentAnswer1 = "";
            currentAnswer2 = "";
            currentAnswer3 = "";

        }


        private string currentContent;
        public string CurrentContent
        {
            get => currentContent;
            set
            {
                currentContent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(currentContent)));
            }
        }

        private string currentAnswer0;
        public string CurrentAnswer0
        {
            get => currentAnswer0;
            set
            {
                currentAnswer0 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(currentAnswer0)));
            }
        }

        private string currentAnswer1;
        public string CurrentAnswer1
        {
            get => currentAnswer1;
            set
            {
                currentAnswer1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(currentAnswer1)));
            }
        }

        private string currentAnswer2;
        public string CurrentAnswer2
        {
            get => currentAnswer2;
            set
            {
                currentAnswer2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(currentAnswer2)));
            }
        }

        private string currentAnswer3;
        public string CurrentAnswer3
        {
            get => currentAnswer3;
            set
            {
                currentAnswer3 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(currentAnswer3)));
            }
        }




        private Question chosenQuestion;
        public Question ChosenQuestion
        {
            get => chosenQuestion;
            set
            {
                chosenQuestion = value;
                chosenQuestionIndex = QuestionList.IndexOf(chosenQuestion);
                if (chosenQuestion != null)
                {
                    CurrentContent = ChosenQuestion.Content;
                    CurrentAnswer0 = ChosenQuestion.Answers[0];
                    CurrentAnswer1 = ChosenQuestion.Answers[1];
                    CurrentAnswer2 = ChosenQuestion.Answers[2];
                    CurrentAnswer3 = ChosenQuestion.Answers[3];
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(chosenQuestion)));
            }
        }

        public ObservableCollection<Question> QuestionList { get; set; }

        private ICommand addQuestion;
        public ICommand AddQuestion
        {
            get
            {
                if (addQuestion == null)
                    addQuestion = new RelayCommand(

                    (o) =>
                    {
                        QuestionList.Add(new Question("Nowe pytanie"));
                    },

                    (o) => true
                    //(o) => chosenQuestionIndex < 0
                    );
                return addQuestion;
            }
        }

        private ICommand saveQuestion;
        public ICommand SaveQuestion
        {
            get
            {
                if (saveQuestion == null)
                    saveQuestion = new RelayCommand(

                    (o) =>
                    {
                        // TODO
                        ChosenQuestion.Content = CurrentContent;
                        ChosenQuestion.Answers[0] = CurrentAnswer0;
                        ChosenQuestion.Answers[1] = CurrentAnswer1;
                        ChosenQuestion.Answers[2] = CurrentAnswer2;
                        ChosenQuestion.Answers[3] = CurrentAnswer3;

                        readyToSave = false;

                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(chosenQuestion)));
                    },

                    (o) => true
                    );
                return saveQuestion;
            }
        }


        private ICommand deleteQuestion;
        public ICommand DeleteQuestion
        {
            get
            {
                if (deleteQuestion == null)
                    deleteQuestion = new RelayCommand(

                    (o) =>
                    {
                        MessageBoxResult result = MessageBox.Show("Chcesz usunąć to pytanie?", "POTWIERDZENIE", MessageBoxButton.YesNo);
                        switch (result)
                        {
                            case MessageBoxResult.Yes:
                                QuestionList.Remove(ChosenQuestion);
                                CleanCurrentValues();
                                break;
                            case MessageBoxResult.No:
                                break;
                        }
                    },

                    (o) => true
                    //(o) => chosenQuestionIndex >= 0
                    );
                return deleteQuestion;
            }
        }

        private void checkChanges()
        {

            //if (TempQuestion.Answers != null)
            //{
            //    if (TempQuestion.Answers.Contains(""))
            //    {
            //        readyToSave = false;
            //    }
            //    else if (TempQuestion.Content == "")
            //    {
            //        readyToSave = false;
            //    }
            //    else if (TempQuestion.Answers == ChosenQuestion.Answers && TempQuestion.Content == ChosenQuestion.Content)
            //    {
            //        readyToSave = false;
            //    }
            //    else readyToSave = true;
            //}
        }

        private void CleanCurrentValues()
        {
            CurrentContent = "";
            CurrentAnswer0 = "";
            CurrentAnswer1 = "";
            CurrentAnswer2 = "";
            CurrentAnswer3 = "";
        }

    }
}
