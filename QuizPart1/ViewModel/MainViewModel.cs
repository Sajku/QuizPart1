using Microsoft.Win32;
using QuizPart1.Modules;
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

        public MainViewModel()
        {
            FilePath = "FILEPATH...123";
            QuizList = new ObservableCollection<Quiz>();

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

            QuizList.Add(currentQuiz);
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(filePath)));
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

                    (o) => true
                    );
                return addQuiz;
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
                                FilePath = openFileDialog1.FileName;
                        },
                        (o) => true
                        );
                return addPath;
            }
        }

    }
}
