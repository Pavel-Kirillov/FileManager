using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку чисел разделенную пробелами");
            Console.WriteLine($"Сумма чисел {Sum(Console.ReadLine())}");
            Console.ReadKey();
        }

        static int Sum(string line)
        {
            int sum = 0;
            int value = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ') value = value * 10 + Convert.ToInt32(line[i] - '0');
                else
                {
                    sum += value;
                    value = 0;
                }
            }
            return sum += value;
        }
    }
}
