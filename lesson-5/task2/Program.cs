using System;
using System.IO;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            File.AppendAllText("startup.txt", $"{DateTime.Now:hh:mm:ss}\n");
        }
    }
}
