using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Как вас зовут? ");
            string name = Console.ReadLine();
            Console.WriteLine($"Привет, {name}, сегодня {DateTime.Now.ToString("dd MMMM yyyy") }");

        }
    }
}
