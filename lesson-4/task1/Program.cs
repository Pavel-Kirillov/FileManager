using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[,] list = { {"Иван", "Иванов", "Иванович" }, { "Петр", "Петров", "Петрович" },{ "Тест", "Тестов","Тестович"} };
            for (int i = 0; i < list.GetLength(0); i++)
            {
                Console.WriteLine(GetFullName(list[i, 0], list[i, 1], list[i, 2]));              
            }
            Console.ReadKey();
        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{lastName} {firstName} {patronymic}";
        }
    }
}
