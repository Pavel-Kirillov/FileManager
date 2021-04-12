using System;
using System.IO;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите данные, числа (от 0 до 255):");
            string str = Console.ReadLine();
            string[] strSplit = str.Split(' ');
            byte[] strToByte = new byte[strSplit.Length];
            for (int i = 0; i < strSplit.Length; i++)
            {
                strToByte[i] = Convert.ToByte(strSplit[i]);
            }
            File.WriteAllBytes("out.txt", strToByte); 
        }
    }
}
