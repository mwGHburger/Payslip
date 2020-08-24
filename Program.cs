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

            double grossIncome = calculateGrossIncome(annualSalary);
            double incomeTax = calculateIncomeTax(annualSalary);
            double netIncome = calculateNetIncome(grossIncome, incomeTax);
            double super = calculateSuper(grossIncome, superRate);

            Console.WriteLine("\nYour payslip has been generated: \n");
            Console.WriteLine($"Name: {name} {surname}");
            Console.WriteLine($"Pay Period: {startDate} - {endDate}");
            Console.WriteLine($"Gross Income: {grossIncome}");
            Console.WriteLine($"Income Tax: {Math.Round(incomeTax)}");
            Console.WriteLine($"Net Income: {Math.Round(netIncome)}");
            Console.WriteLine($"Super: {Math.Round(super)}");
            Console.WriteLine("\nThank you for using MYOB!");
        }
        
        private static double calculateGrossIncome(int annualSalary)
        {
            return annualSalary / 12;
        }

        private static double calculateIncomeTax(int annualSalary)
        {
            if (annualSalary >= 180001)
            {
                return incomeTaxFormula(54232, annualSalary, 180000, 0.45);
            }
            else if (annualSalary >= 87001)
            {
                return incomeTaxFormula(19822, annualSalary, 87000, 0.37);
            }
            else if (annualSalary >= 37001)
            {
                return incomeTaxFormula(3572, annualSalary, 37000, 0.325);
            }
            else if (annualSalary >= 18201)
            {
                return incomeTaxFormula(0, annualSalary, 18200, 0.19);
            }
            else
            {
                return 0;
            }
        }

        private static double incomeTaxFormula(int baseAmount, int annualSalary, int incomeThreshold, double taxRate)
        {
            return (baseAmount + (annualSalary - incomeThreshold) * taxRate) / 12;
        }

        private static double calculateNetIncome(double grossIncome, double incomeTax)
        {
            return grossIncome - incomeTax;
        }

        private static double calculateSuper(double grossIncome, double superRate)
        {
            return grossIncome * superRate / 100;
        }
    }
}
