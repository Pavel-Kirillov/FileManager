using System;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = " Предложение один Теперь предложение два Предложение три";
            Console.WriteLine(str1);
            Console.WriteLine(NormalizeStr(str1));
            Console.ReadKey();
        }

        static bool Uppercase(char ch)
        {
            return ch >= 'А' && ch <= 'Я';
        }
        static string NormalizeStr(string str)
        {
            string strN = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i != 0 && str[i] == ' ' && !Uppercase(str[i - 1]) && Uppercase(str[i + 1])) strN += '.';
                strN += str[i];
                if (i == str.Length - 1) strN += '.';
            }
            return strN;
        }
    }
}
