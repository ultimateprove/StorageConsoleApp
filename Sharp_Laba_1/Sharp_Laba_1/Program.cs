﻿using System;
using System.Collections.Generic;

namespace Sharp_Laba_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Printer printer1 = new Printer("Zrinter1", 3, 100, 50, "A4");
            Printer printer2 = new Printer("Drinter2", 2, 200, 60, "A3");
            Printer printer3 = new Printer("Arinter2", 1, 200, 60, "A3");

            //Product.FlagOfDisplay = false;
            //Console.WriteLine(printer1);
            //Console.WriteLine(printer2);


            //Product.FlagOfDisplay = true;
            //Console.WriteLine(printer1);
            //Console.WriteLine(printer2);

            Storage storage1 = 3;
          

            storage1.Put(printer1);
            storage1.Put(printer2);
            storage1.Put(printer3);

            Console.WriteLine(storage1);

            storage1.SortByCode();

            Console.WriteLine(storage1);

            storage1.SortByName();

            Console.WriteLine(storage1);

            Console.ReadKey();   
        }
    }
}