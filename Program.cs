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
            double super = grossIncome * superRate;

            Console.WriteLine("\nYour payslip has been generated: \n");

            Console.WriteLine($"Name: {name} {surname}");
            Console.WriteLine($"Pay Period: {startDate} - {endDate}");
            Console.WriteLine($"Gross Income: {grossIncome}");
            Console.WriteLine($"Income Tax: {incomeTax}");
            Console.WriteLine($"Net Income: {netIncome}");
            Console.WriteLine($"Super: {super}");
            Console.WriteLine("\nThank you for using MYOB!");
        }
    }
}
