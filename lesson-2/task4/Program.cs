using System;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string companyName = "ООО Заря";
            long inn = 5987653340;
            string product = "Стул";
            double cash = 4999.99;
            decimal tax = 4999.99M * 0.18M;
            DateTime date = new DateTime(2001,7,12,8,3,0);

            Console.WriteLine(companyName);
            Console.WriteLine($"ИНН {inn}");
            Console.WriteLine(date.ToString("dd.MM.yy hh:mm"));
            Console.WriteLine();
            Console.WriteLine($"{product}\t\t= {Convert.ToDecimal(cash) - tax:0.00}");
            Console.WriteLine($"наличные\t= {cash}");
            Console.WriteLine($"НДС\t\t= {tax:0.00}");
            Console.WriteLine($"Итого\t\t= {cash}");
            
            Console.ReadKey();
        }
    }
}
