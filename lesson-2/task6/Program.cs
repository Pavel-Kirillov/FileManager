using System;

namespace task6
{
    class Program
    {
        [Flags]
        enum week
        {
            Понедельник =   0b_0000001,
            Вторник =       0b_0000010,
            Среда =         0b_0000100,
            Четверг =       0b_0001000,
            Пятница =       0b_0010000,
            Суббота =       0b_0100000,
            Воскресенье =   0b_1000000,
        }
        
        static void Main(string[] args)
        {
            week office1 = week.Вторник | week.Среда | week.Четверг | week.Пятница ;
            week office2 = office1 | week.Суббота | week.Воскресенье | week.Понедельник;

            Console.WriteLine($"Первый офис работает - {office1}");
            Console.WriteLine($"Второй офис работает - {office2}");
            Console.ReadKey();
        }
    }
}
