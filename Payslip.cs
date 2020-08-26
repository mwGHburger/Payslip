using System;

namespace Payslip
{
    public class Payslip
    {
        // CONSTRUCTOR
        public Payslip(string name, string surname, int annualSalary, double superRate, string startDate, string endDate)
        {
            this.Name = name;
            this.Surname = surname;
            this.AnnualSalary = annualSalary;
            this.SuperRate = superRate;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.GrossIncome = 0;
            this.IncomeTax = 0;
            this.NetIncome = 0;
            this.Super = 0;
        }

        // METHODS
        public static void Generate()
        {
            Payslip payslip = GetUserInformation();
            
            payslip.GrossIncome = payslip.CalculateGrossIncome(payslip.AnnualSalary);
            payslip.IncomeTax = payslip.CalculateIncomeTax(payslip.AnnualSalary);
            payslip.NetIncome = payslip.CalculateNetIncome(payslip.GrossIncome, payslip.IncomeTax);
            payslip.Super = payslip.CalculateSuper(payslip.GrossIncome, payslip.SuperRate);

            payslip.DisplayResults();
        }

        private static Payslip GetUserInformation()
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
            return new Payslip(name, surname, annualSalary, superRate, startDate, endDate);
        }
        private void DisplayResults()
        {
            Console.WriteLine("\nYour payslip has been generated: \n");
            Console.WriteLine($"Name: {Name} {Surname}");
            Console.WriteLine($"Pay Period: {StartDate} - {EndDate}");
            Console.WriteLine($"Gross Income: {GrossIncome}");
            Console.WriteLine($"Income Tax: {Math.Round(IncomeTax)}");
            Console.WriteLine($"Net Income: {Math.Round(NetIncome)}");
            Console.WriteLine($"Super: {Math.Round(Super)}");
            Console.WriteLine("\nThank you for using MYOB!");
        }
        private double CalculateGrossIncome(int annualSalary)
        {
            return annualSalary / 12;
        }

        private double CalculateIncomeTax(int annualSalary)
        {
            if (annualSalary >= 180001)
            {
                return UseIncomeTaxFormula(54232, annualSalary, 180000, 0.45);
            }
            else if (annualSalary >= 87001)
            {
                return UseIncomeTaxFormula(19822, annualSalary, 87000, 0.37);
            }
            else if (annualSalary >= 37001)
            {
                return UseIncomeTaxFormula(3572, annualSalary, 37000, 0.325);
            }
            else if (annualSalary >= 18201)
            {
                return UseIncomeTaxFormula(0, annualSalary, 18200, 0.19);
            }
            else
            {
                return 0;
            }
        }

        private double UseIncomeTaxFormula(int baseAmount, int annualSalary, int incomeThreshold, double taxRate)
        {
            return (baseAmount + (annualSalary - incomeThreshold) * taxRate) / 12;
        }

        private double CalculateNetIncome(double grossIncome, double incomeTax)
        {
            return grossIncome - incomeTax;
        }

        private double CalculateSuper(double grossIncome, double superRate)
        {
            return grossIncome * superRate / 100;
        }

        // PROPERTIES
        public string Name
        {
            get;
            private set;
        }

        public string Surname
        {
            get;
            private set;
        }

        public int AnnualSalary
        {
            get;
            private set;
        }

        public double SuperRate
        {
            get;
            private set;
        }

        public string StartDate
        {
            get;
            private set;
        }

        public string EndDate
        {
            get;
            private set;
        }

        public double GrossIncome
        {
            get; set;
        }

        public double IncomeTax
        {
            get; set;
        }

        public double NetIncome
        {
            get; set;
        }

        public double Super
        {
            get; set;
        }
    }
}