using System;

namespace test4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i =0;i<arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine("\nЗадайте величину смещения: ");
            int offset = Convert.ToInt32(Console.ReadLine());

            if (Math.Abs(offset) > arr.Length) offset = offset - (offset / arr.Length) * arr.Length;
            if (offset <= 0) offset = arr.Length + offset;
            
            for (int i = 0, tmpOffset = 0, tmpOffset2 = 0 , tmpFirst; i < arr.Length && arr.Length != offset;)
            {
                tmpFirst = arr[tmpOffset2];
                do
                {
                    tmpOffset += offset;
                    if (tmpOffset >= arr.Length) tmpOffset -= arr.Length;
                    int tmpSecond = arr[tmpOffset];
                    arr[tmpOffset] = tmpFirst;
                    tmpFirst = tmpSecond;
                    i++;
                } while (tmpOffset != tmpOffset2);
                tmpOffset = ++tmpOffset2;
                }

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
            Console.ReadKey();   
        }
    }
}
