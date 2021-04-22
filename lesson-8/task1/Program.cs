using System;
using GreetingLibrary;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeting.Say();
            Greeting.Say("ru");
            Console.ReadKey();
        }
    }
}
