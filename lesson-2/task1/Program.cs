using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите минимальную и максимальную температуру за сутки:");
            double minTemp = Convert.ToDouble(Console.ReadLine());
            double maxTemp = Convert.ToDouble(Console.ReadLine());
            double averageTemp = (minTemp + maxTemp) /2;
            Console.WriteLine($"Средняя температура {averageTemp}.");
            Console.ReadLine();
        }
    }
}
