using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string line = Console.ReadLine();
            for (int i = line.Length - 1; i >= 0; i--)
            {
                Console.Write(line[i]);
            }
            Console.ReadKey();
        }
    }
}
