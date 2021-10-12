using System;

namespace Invoice_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to cab invoice generator");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double fare = invoiceGenerator.CalculateFare(50.0, 5);
            Console.WriteLine($"Fare : {fare}");
        }
    }
}
