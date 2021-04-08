using System;

namespace task3
{
    class Program
    {
        enum Season
        {
            winter,
            spring,
            summer,
            autumn,
            error
        }
        static void Main(string[] args)
        {
            string error;
            do
            {
                Console.Write("Введите номер месяца: ");
                Console.WriteLine(GetNameSeason(GetSeason(Convert.ToInt32(Console.ReadLine())),out error));
            } while (error != "");
            Console.ReadKey();
        }

        static Season GetSeason(int number)
        {
            if ((number >= 1 && number <= 2) || number == 12) return Season.winter;
            else if (number >= 3 && number <= 5) return Season.spring;
            else if (number >= 6 && number <= 8) return Season.summer;
            else if (number >= 8 && number <= 10) return Season.autumn;
            else return Season.error;
        }

        static string GetNameSeason(Season season, out string error)
        {
            error = "";
            switch (season){
                case Season.winter: return "Зима";
                case Season.spring: return "Весна";
                case Season.summer: return "Лето";
                case Season.autumn: return "Осень";
                default: return error = "Ошибка. Введите число от 1 до 12";
            }
        }
    }
}
