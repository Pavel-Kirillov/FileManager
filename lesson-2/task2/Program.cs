using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер текущего месяца");
            string month = Console.ReadLine();
            DateTime date = new DateTime();
            date = date.AddMonths(Convert.ToInt32(month) - 1);
            Console.WriteLine(date.ToString("MMMM"));
            Console.ReadLine();
        }
    }
}
