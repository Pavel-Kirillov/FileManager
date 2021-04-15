using System;

namespace task4
{
    public class Employee
    {
        public string FullName;
        public string Position;
        public string Email;
        public string PhoneNumber;
        public float Salary;
        public int Age;
        public Employee(string fullName, string position, string email, string phoneNumber, float salary, int age)
        {
            FullName = fullName;
            Position = position;
            Email = email;
            PhoneNumber = phoneNumber;
            Salary = salary;
            Age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[5];
            employees[0] = new Employee("Ivanov Ivan", "Engineer", "ivivan@mailbox.com", "892312312", 30000, 34);
            employees[1] = new Employee("Petrov Petr", "Chief Engineer", "petrov@mailbox.com", "892312313", 40000, 43);
            employees[2] = new Employee("Fedorov Fedor", "Locksmith", "fedorov@mailbox.com", "892312315", 30200, 67);
            employees[3] = new Employee("Mikhaylov Mikhail", "Turner", "mikhaylov@mailbox.com", "892312317", 33000.5f, 47);
            employees[4] = new Employee("Alekseev Aleksey", "CEO", "alekseev@mailbox.com", "892312318", 70000, 53);

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].Age > 40) Console.WriteLine($"{employees[i].FullName} {employees[i].Position}" +
                    $" {employees[i].Email} {employees[i].PhoneNumber} {employees[i].Salary} {employees[i].Age}");
            }
            Console.ReadKey();
        }
        
    }
}
