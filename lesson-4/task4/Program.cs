using System;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            Console.WriteLine(Fib(Convert.ToInt32(Console.ReadLine())));
            Console.ReadLine();
        }

        static long Fib(int number)
        {
            if (number == 1) return 1;
            else if (number == 0) return 0;
            else return Fib(number - 1) + Fib(number - 2);
        }
    }
}
