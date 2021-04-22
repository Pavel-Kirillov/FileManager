using System;

namespace GreetingLibrary
{
    public class Greeting
    {


        public static void Say(string lang = "EN")
        {
            if (lang == "ru" || lang == "RU")
            {
                Console.WriteLine("Привет Мир!");
            }
            else if (lang == "en" || lang == "EN") Console.WriteLine("Hello Word!");

        }

    }
}
