using System;

namespace Payslip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the payslip generator!\n");

            Console.Write("Please input your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"DEBUG: name is {name}");

            Console.Write("Please input your surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine($"DEBUG: surname is {surname}");
            
            Console.Write("Please enter your annual salary: ");
            int annualSalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"DEBUG: annualSalary is {annualSalary}");

            Console.Write("Please enter your super rate: ");
            double superRate = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"DEBUG: superRate is {superRate}");

            Console.Write("Please enter your payment start date: ");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine($"DEBUG: startDate is {startDate}");

            Console.Write("Please enter your payment end date: ");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine($"DEBUG: endDate is {endDate}");

            Console.WriteLine("\nYour payslip has been generated: \n");
            
        }
    }
}
