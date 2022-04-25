using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace QuizPart1.Model
{
    class FileManagment
    {
        public static void writeFile(Quiz chosenQuiz)
        {
            ICipher caesar1 = new CaesarCipher(1);

            string serialized = JsonSerializer.Serialize(chosenQuiz);
            string encrypted = caesar1.Encrypt(serialized);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JSON File|*.json";
            saveFileDialog1.Title = "Zapisz plik";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllText(saveFileDialog1.FileName, encrypted);
                MessageBox.Show("Pomyślnie zapisano plik");
            }
        }

        public static Quiz readFile(string fileContent)
        {
            ICipher caesar1 = new CaesarCipher(1);

            string text = caesar1.Decrypt(fileContent);
            Console.WriteLine(text);
            Quiz quizFromFile = JsonSerializer.Deserialize<Quiz>(text);
            return quizFromFile;
        }
    }
}
