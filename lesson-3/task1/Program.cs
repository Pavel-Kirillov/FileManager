using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] arr = new int [5, 5];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i, i] = 1;
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(arr[i, j]);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
