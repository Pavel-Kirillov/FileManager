using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {

            string[,] phonebook = new string[5, 2];
            string operation;
            int numberString = 0;
            do
            {
                Console.WriteLine("Телефонный справочник.\nДобавление записи (add), Просмотр (list), Выход (exit).\nВведите команду");
                operation = Console.ReadLine();
            
                if (operation == "add")
                {
                    if (numberString < phonebook.GetLength(0))
                    {
                        Console.Write("Имя: ");
                        string name = Console.ReadLine();
                        Console.Write("Телефон: ");
                        string phone = Console.ReadLine();
                        phonebook[numberString, 0] = name;
                        phonebook[numberString, 1] = phone;
                        numberString++;
                    }else Console.WriteLine("Закончилось место в справочнике.\nВыбрите другую операцию.");

                }
                else if (operation == "list")
                {
                    for (int i = 0; i < phonebook.GetLength(0); i++)
                    {
                        for (int j=0;j<phonebook.GetLength(1);j++)
                            Console.Write($"{phonebook[i, j]} ");
                        Console.WriteLine();
                    }
                }
           
            } while (operation != "exit");

        }
    }
}
