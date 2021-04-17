using System;

namespace task2
{
    public enum ErrorCode{
        MyArraySizeException,
        MyArrayDataException
    }
    class Program
    {
        static void Main(string[] args)
        {

            string[,] arr = { { "1", "2", "3", "4" }, { "5", "6", "d", "8" }, { "9", "10", "11", "12" }, { "13", "14", "15", "16" } };
            string[,] arr2 = new string[3, 4];
            string[,] arr3 = { { "1", "2", "3", "4" }, { "5", "6", "7", "8" }, { "9", "10", "11", "12" }, { "13", "14", "15", "16" } };

            ErrorProcessing(arr);
            ErrorProcessing(arr2);
            ErrorProcessing(arr3);


            Console.ReadKey();
        }

        private static void ErrorProcessing(string[,] arr)
        {
            try
            {
                Console.WriteLine(SumArr(arr));
            }
            catch (ErrorArr er) when (er.Code == ErrorCode.MyArraySizeException)
            {
                Console.WriteLine("Массив другого размера.");
            }
            catch (ErrorArr er) when (er.Code == ErrorCode.MyArrayDataException)
            {
                Console.WriteLine($"Несоответствие типа данных в ячейке {er.i} {er.j}");
            }
        }

        private static int SumArr(string[,] arr)
        {
            
            if (arr.GetLength(0) != 4 || arr.GetLength(1) != 4)
            {
                throw new ErrorArr(ErrorCode.MyArraySizeException,0,0);
            }else
            {
                int res = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        try
                        {
                            res += Convert.ToInt32(arr[i, j]);
                        }
                        catch (FormatException)
                        {
                            throw new ErrorArr(ErrorCode.MyArrayDataException,i + 1,j + 1);
                        }
                    }
                }
                return res;
            }
            
        }
        public class ErrorArr : Exception
        {
            public ErrorCode Code { get; }
            public int i;
            public int j;

            public ErrorArr(ErrorCode code, int i, int j)
            {
                Code = code;
                this.i = i;
                this.j = j;
            }
        }
    }
}
