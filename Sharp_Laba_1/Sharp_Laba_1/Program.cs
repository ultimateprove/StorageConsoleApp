using System;

namespace Sharp_Laba_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var printer1 = new Printer("Zrinter1", 1000000, 100, 50, "A4");
            var printer2 = new Printer("Drinter2", 20, 200, 60, "A3");
            var printer3 = new Printer("Arinter2", 10, 300, 60, "A3");

            

            Console.ReadKey();   
        }
    }
}