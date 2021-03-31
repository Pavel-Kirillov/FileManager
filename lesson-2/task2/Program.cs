using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер текущего месяца");
            int month = Convert.ToInt32(Console.ReadLine());
            DateTime date = new DateTime();
            date = date.AddMonths(month - 1);
            Console.WriteLine(date.ToString("MMMM"));
            Console.ReadLine();
        }
    }
}
