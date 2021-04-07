using System;

namespace task3_asterisk_
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
                    int x, y, tmpX, tmpY, direction;
                    do
                    {
                        x = position.Next(land.GetLength(0) - i);
                        y = position.Next(land.GetLength(1) - i);
                        direction = position.Next(2);
                        pos = true;
                        tmpX = x;
                        tmpY = y;
                        for (int n = 0; n <= i; n++)
                        {
                            if (direction == 0) tmpY = y + n;
                            else tmpX = x + n;
                            if (land[tmpX , tmpY] == 'X') pos = false;
                        }
                            
                    } while (!pos);
                    tmpX = x;
                    tmpY = y;
                    for (int n = 0; n <= i; n++) // размер корабля
                    {
                        if (direction == 0) tmpY = y + n;
                        else tmpX = x + n;
                        land[tmpX, tmpY] = 'X';
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
