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
    class QuizViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Quiz currentQuiz;
        private string QuizName;

        public QuizViewModel(Quiz currentQuiz1)
        {
            QuestionList = new ObservableCollection<Question>();

            foreach (Question o in currentQuiz1.Questions)
            {
                QuestionList.Add(o);
            }
            currentQuiz = currentQuiz1;
            QuizName = currentQuiz.Name;

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
