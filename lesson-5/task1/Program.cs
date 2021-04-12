using System;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите данные:");
            string str = Console.ReadLine();
            File.WriteAllText("out.txt", str);           
        }
    }
}
