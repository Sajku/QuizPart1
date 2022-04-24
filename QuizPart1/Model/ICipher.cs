using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPart1.Model
{
    interface ICipher
    {
        string Encrypt(string str);
        string Decrypt(string str);
    }
}
