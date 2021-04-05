using System;

namespace test3_asterisk_
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] land = new char[10, 10];
            for (int i = 0; i < land.GetLength(0); i++)
            {
                for (int j = 0; j < land.GetLength(1); j++)
                    land[i, j] = 'O';
            }

            Random position = new Random();

            for (int i = 0; i < 4 ; i++) // колличество типов кораблей
            {
                for (int j = 0; j < 4 - i; j++) // количество кораблей
                {
                    bool pos;
                    int x, y, direction;
                    do
                    {
                        x = position.Next(land.GetLength(0) - i);
                        y = position.Next(land.GetLength(1) - i);
                        direction = position.Next(2);
                        pos = true;
                        for (int n = 0; n <= i; n++)
                        {
                            if (land[(direction == 0 ? x : x + n ), (direction != 0 ? y : y + n)] == 'X') pos = false;
                        }
                            
                    } while (!pos);
       
                    for (int n = 0; n <= i; n++) // размер корабля
                    {
                        land[(direction == 0 ? x : x + n ), (direction != 0 ? y : y + n)] = 'X';
                    }
                }
            }

            for (int i = 0; i < land.GetLength(0); i++)
            {
                for (int j = 0; j < land.GetLength(1); j++)
                    Console.Write(land[i, j]);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
