using QuizPart1.Model;
using System;
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
            QuizName = currentQuiz1.Name;
            chosenQuestionIndex = -1;
            readyToSave = false;
            listboxEnabled = true;

            currentContent = "";
            currentAnswer0 = "";
            currentAnswer1 = "";
            currentAnswer2 = "";
            currentAnswer3 = "";

        }

        private string quizName;
        public string QuizName
        {
            get => quizName;
            set
            {
                quizName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(quizName)));
            }
        }

        private string currentContent;
        public string CurrentContent
        {
            get => currentContent;
            set
            {
                currentContent = value;
                checkChanges();
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
                checkChanges();
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
                checkChanges();
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
                checkChanges();
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
                checkChanges();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(currentAnswer3)));
            }
        }

        private bool check0;
        public bool Check0
        {
            get => check0;
            set
            {
                check0 = value;
                checkChanges();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(check0)));
            }
        }

        private bool check1;
        public bool Check1
        {
            get => check1;
            set
            {
                check1 = value;
                checkChanges();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(check1)));
            }
        }

        private bool check2;
        public bool Check2
        {
            get => check2;
            set
            {
                check2 = value;
                checkChanges();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(check2)));
            }
        }

        private bool check3;
        public bool Check3
        {
            get => check3;
            set
            {
                check3 = value;
                checkChanges();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(check3)));
            }
        }

        private bool listboxEnabled;
        public bool ListboxEnabled
        {
            get => listboxEnabled;
            set
            {
                listboxEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(listboxEnabled)));
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

                    Check0 = false;
                    Check1 = false;
                    Check2 = false;
                    Check3 = false;
                    foreach (int o in ChosenQuestion.Correct)
                    {
                        if (o == 0)
                        {
                            Check0 = true;
                        }
                        if (o == 1)
                        {
                            Check1 = true;
                        }
                        if (o == 2)
                        {
                            Check2 = true;
                        }
                        if (o == 3)
                        {
                            Check3 = true;
                        }
                    }
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
                        currentQuiz.Questions.Add(new Question("Nowe pytanie"));
                        ListboxEnabled = true;
                    },

                    (o) => !readyToSave
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
                        Question temp = new Question(CurrentContent);
                        temp.Answers[0] = CurrentAnswer0;
                        temp.Answers[1] = CurrentAnswer1;
                        temp.Answers[2] = CurrentAnswer2;
                        temp.Answers[3] = CurrentAnswer3;
                        if (Check0)
                            temp.Correct.Add(0);
                        if (Check1)
                            temp.Correct.Add(1);
                        if (Check2)
                            temp.Correct.Add(2);
                        if (Check3)
                            temp.Correct.Add(3);

                        currentQuiz.Questions.Insert(chosenQuestionIndex, temp);
                        currentQuiz.Questions.RemoveAt(chosenQuestionIndex + 1);
                        QuestionList.Insert(chosenQuestionIndex, temp);
                        QuestionList.RemoveAt(chosenQuestionIndex + 1);
                        

                        readyToSave = false;
                        ListboxEnabled = true;

                    },

                    (o) => readyToSave
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
                                currentQuiz.Questions.Remove(ChosenQuestion);
                                QuestionList.Remove(ChosenQuestion);
                                CleanCurrentValues();
                                ListboxEnabled = true;
                                break;
                            case MessageBoxResult.No:
                                break;
                        }
                    },

                    (o) => chosenQuestion != null
                    //(o) => chosenQuestionIndex >= 0
                    );
                return deleteQuestion;
            }
        }

        private void checkChanges()
        {
            int changed = 0;
            int checkedCount = 0;
            if (ChosenQuestion != null)
            {
                if (CurrentContent != ChosenQuestion.Content && CurrentContent.Trim() != "")
                    changed = 1;
                else if (CurrentAnswer0 != ChosenQuestion.Answers[0] && CurrentAnswer0.Trim() != "")
                    changed = 1;
                else if (CurrentAnswer1 != ChosenQuestion.Answers[1] && CurrentAnswer1.Trim() != "")
                    changed = 1;
                else if (CurrentAnswer2 != ChosenQuestion.Answers[2] && CurrentAnswer2.Trim() != "")
                    changed = 1;
                else if (CurrentAnswer3 != ChosenQuestion.Answers[3] && CurrentAnswer3.Trim() != "")
                    changed = 1;

                if (Check0)
                    checkedCount++;
                if (Check1)
                    checkedCount++;
                if (Check2)
                    checkedCount++;
                if (Check3)
                    checkedCount++;

                if (changed > 0 && checkedCount > 0)
                {
                    readyToSave = true;
                    ListboxEnabled = false;
                }
                else
                {
                    readyToSave = false;
                    ListboxEnabled = true;
                }
            }
        }

        private void CleanCurrentValues()
        {
            CurrentContent = "";
            CurrentAnswer0 = "";
            CurrentAnswer1 = "";
            CurrentAnswer2 = "";
            CurrentAnswer3 = "";
            check0 = false;
            check1 = false;
            check2 = false;
            check3 = false;
        }

    }
}
