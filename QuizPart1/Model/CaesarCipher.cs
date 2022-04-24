using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPart1.Model
{
    class CaesarCipher : ICipher
    {
        private int key;

        public CaesarCipher(int k)
        {
            key = k;
        }

        public string Decrypt(string str)
        {
            string output = string.Empty;
            int key1 = 0;

            foreach (char ch in str)
            {
                if (char.IsLetter(ch))
                    key1 = 26 - key;
                else
                    key1 = 10 - key;
                output += Cipher(ch, key1);
            }
            return output;
        }

        public string Encrypt(string str)
        {
            string output = string.Empty;

            foreach (char ch in str)
            {
                output += Cipher(ch, key);
            }
            return output;
        }

        private static char Cipher(char ch, int key)
        {
            if (char.IsLetter(ch))
            {
                char offset = char.IsUpper(ch) ? 'A' : 'a';
                return (char)(((ch + key - offset) % 26) + offset); ;
            }
            else if (char.IsDigit(ch))
            {
                char offset = '0';
                return (char)(((ch + key - offset) % 10) + offset);
            }
            else
                return ch;
        }

    }
}
