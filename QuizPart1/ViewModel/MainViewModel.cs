using Microsoft.Win32;
using QuizPart1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace QuizPart1.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool fileChosen;
        private bool quizChosen;
        public Quiz currentQuiz;
        private string fileContent;

        public MainViewModel()
        {
            fileChosen = false;
            QuizList = new ObservableCollection<Quiz>();
            QuizName = "";
            fileContent = "";
            

            Quiz currentQuiz1 = new Quiz("Pierwszy");

            List<string> lista1 = new List<string>
            {
                "Odpowiedz 1",
                "Odpowiedz 2 - p",
                "Odpowiedz 3",
                "Odpowiedz 4"
            };

            currentQuiz1.Questions.Add(new Question("Tresc pytania numer 1", lista1, 1, -1));
            lista1.RemoveAt(0);
            lista1.RemoveAt(0);
            lista1.RemoveAt(0);
            lista1.RemoveAt(0);
            lista1.Add("Odp A");
            lista1.Add("Odp B");
            lista1.Add("Odp C");
            lista1.Add("Odp D - p");
            currentQuiz1.Questions.Add(new Question("PYTANIE NUMER 2", lista1, 3, -1));

            lista1.RemoveAt(0);
            lista1.RemoveAt(0);
            lista1.RemoveAt(0);
            lista1.RemoveAt(0);
            lista1.Add("ANSWER ABC - p");
            lista1.Add("ANSWER DEF");
            lista1.Add("ANSWER GHI");
            lista1.Add("ANSWER JKL");
            currentQuiz1.Questions.Add(new Question("QUESTION 3.", lista1, 0, -1));

            lista1.RemoveAt(0);
            lista1.RemoveAt(0);
            lista1.RemoveAt(0);
            lista1.RemoveAt(0);
            lista1.Add("aaaaaaaaaAAAAAAA");
            lista1.Add("bbbbbbBBBBBBBB");
            lista1.Add("ccccccccCCCCCCCCCc - p");
            lista1.Add("dddDDD");
            currentQuiz1.Questions.Add(new Question("jdkjqkdnsdnasndasdka", lista1, 2, -1));

            string fileName = "dane.json";
            string json = JsonSerializer.Serialize(currentQuiz1);
            File.WriteAllText(fileName, json);

            QuizList.Add(currentQuiz1);

            currentQuiz = currentQuiz1;
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

        private string filePath;
        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
                fileChosen = true;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(filePath)));
            }
        }

        private Quiz chosenQuiz;
        public Quiz ChosenQuiz
        {
            get => chosenQuiz;
            set
            {
                chosenQuiz = value;
                quizChosen = true;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(chosenQuiz)));
            }
        }

        public ObservableCollection<Quiz> QuizList { get; set; }


        private ICommand addQuiz;
        public ICommand AddQuiz
        {
            get
            {
                if (addQuiz == null)
                    addQuiz = new RelayCommand(

                    (o) =>
                    {
                        QuizList.Add(new Quiz(QuizName));
                    },

                    (o) => !quizName.Equals("")
                    );
                return addQuiz;
            }
        }

        private ICommand readFile;
        public ICommand ReadFile
        {
            get
            {
                if (readFile == null)
                    readFile = new RelayCommand(

                    (o) =>
                    {
                        Quiz quizFromFile = JsonSerializer.Deserialize<Quiz>(fileContent);
                        QuizList.Add(quizFromFile);
                    },

                    (o) => fileChosen
                    );
                return readFile;
            }
        }

        private ICommand writeFile;
        public ICommand WriteFile
        {
            get
            {
                if (writeFile == null)
                    writeFile = new RelayCommand(

                    (o) =>
                    {
                        // TO DO
                    },

                    (o) => quizChosen
                    );
                return writeFile;
            }
        }

        private ICommand addPath;
        public ICommand AddPath
        {
            get
            {
                if (addPath == null)
                    addPath = new RelayCommand(

                        (o) =>
                        {
                            OpenFileDialog openFileDialog1 = new OpenFileDialog();
                            openFileDialog1.Title = "Wybierz plik quizu";
                            openFileDialog1.DefaultExt = "json";
                            openFileDialog1.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                            openFileDialog1.FilterIndex = 1;
                            openFileDialog1.CheckFileExists = true;
                            openFileDialog1.CheckPathExists = true;


                            if (openFileDialog1.ShowDialog() == true)
                            {
                                FilePath = openFileDialog1.FileName;
                                var fileStream = openFileDialog1.OpenFile();

                                using (StreamReader reader = new StreamReader(fileStream))
                                {
                                    fileContent = reader.ReadToEnd();
                                }
                            }
                        },
                        (o) => true
                        );
                return addPath;
            }
        }

        private ICommand editQuiz;
        public ICommand EditQuiz
        {
            get
            {
                if (editQuiz == null)
                    editQuiz = new RelayCommand(

                    (o) =>
                    {
                        //Application.Current.MainWindow = new QuizWindow(ChosenQuiz);
                        //Application.Current.MainWindow.Show();

                        Application.Current.MainWindow.Hide();
                        QuizWindow win1 = new QuizWindow(ChosenQuiz);
                        win1.ShowDialog();
                        Application.Current.MainWindow.Show();

                    },

                    (o) => quizChosen
                    );
                return editQuiz;
            }
        }

    }
}
