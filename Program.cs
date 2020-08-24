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

            Console.Write("Please input your surname: ");
            string surname = Console.ReadLine();
            
            Console.Write("Please enter your annual salary: ");
            int annualSalary = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter your super rate: ");
            double superRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please enter your payment start date: ");
            string startDate = Console.ReadLine();

            Console.Write("Please enter your payment end date: ");
            string endDate = Console.ReadLine();

            double grossIncome = annualSalary / 12;
            double incomeTax;
            if (annualSalary >= 180001)
            {
                incomeTax = (54232 + (annualSalary - 180000) * 0.45) / 12;
            }
            else if (annualSalary >= 87001)
            {
                incomeTax = (19822 + (annualSalary - 87000) * 0.37) / 12;
            }
            else if (annualSalary >= 37001)
            {
                incomeTax = (3572 + (annualSalary - 37000) * 0.325) / 12;
            }
            else if (annualSalary >= 18201)
            {
                incomeTax = ((annualSalary - 18200) * 0.19) / 12;
            }
            else
            {
                incomeTax = 0;
            }

            double netIncome = grossIncome - incomeTax;
            double super = grossIncome * superRate / 100;

            Console.WriteLine("\nYour payslip has been generated: \n");

            Console.WriteLine($"Name: {name} {surname}");
            Console.WriteLine($"Pay Period: {startDate} - {endDate}");
            Console.WriteLine($"Gross Income: {grossIncome}");
            Console.WriteLine($"Income Tax: {Math.Round(incomeTax)}");
            Console.WriteLine($"Net Income: {Math.Round(netIncome)}");
            Console.WriteLine($"Super: {Math.Round(super)}");
            Console.WriteLine("\nThank you for using MYOB!");
        }
    }
}
