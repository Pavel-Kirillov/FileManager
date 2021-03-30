using System;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер месяца");
            int month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите минимальную и максимальную температуру за сутки:");
            double minTemp = Convert.ToDouble(Console.ReadLine());
            double maxTemp = Convert.ToDouble(Console.ReadLine());
            double averageTemp = (minTemp + maxTemp) / 2;

            if (((month > 0 && month < 3) || month == 12) && averageTemp > 0) Console.WriteLine("Дождливая зима.");
            
            Console.ReadKey();
        }
    }
}
