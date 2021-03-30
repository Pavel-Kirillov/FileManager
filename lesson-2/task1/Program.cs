using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите минимальную и максимальную температуру за сутки:");
            string minTemp = Console.ReadLine();
            string maxTemp = Console.ReadLine();
            double minTempNumerical = Convert.ToDouble(minTemp);
            double maxTempNumerical = Convert.ToDouble(maxTemp);
            double averageTemp = (minTempNumerical + maxTempNumerical) /2;
            Console.WriteLine($"Средняя температура {averageTemp}.");
            Console.ReadLine();
        }
    }
}
