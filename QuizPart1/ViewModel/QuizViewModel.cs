using Microsoft.Win32;
using QuizPart1.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace QuizPart1.ViewModel
{
    class QuizViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public QuizViewModel(Quiz currentQuiz)
        {
            QuestionList = new ObservableCollection<Question>();

            foreach (Question o in currentQuiz.Questions)
            {
                QuestionList.Add(o);
            }


        }

        public ObservableCollection<Question> QuestionList { get; set; }



        //private ICommand editQuiz;
        //public ICommand EditQuiz
        //{
        //    get
        //    {
        //        if (editQuiz == null)
        //            editQuiz = new RelayCommand(

        //            (o) =>
        //            {
        //                Application.Current.MainWindow = new QuizWindow();

        //                Application.Current.MainWindow.Show();
        //            },

        //            (o) => true
        //            );
        //        return editQuiz;
        //    }
        //}

    }
}
