using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizPart1.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            FilePath = "FILEPATH...";
        }

        private string filePath = "";
        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(filePath)));
            }
        }

        public void fileBtn(object sender, RoutedEventArgs e)
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

        }
    }
}
