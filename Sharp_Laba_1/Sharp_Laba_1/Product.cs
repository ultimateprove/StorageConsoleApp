using System;
using static Sharp_Laba_1.BarCode;

namespace Sharp_Laba_1
{
    /// <summary>
    /// Класс продукции
    /// </summary>
    public abstract class Product
    {
        
        public int NumericCode { get; set; }

        public string Barcode 
        {
            get => ToBarcode(NumericCode);
            set => NumericCode = ToNumericCode(value);
        }

        public string Name { get; set; }

        public static bool FlagOfDisplay { get; set; } = true;
        

        protected Product(string name, int numericCode)
        {
            Name = name;
            NumericCode = numericCode;
        }

        public override string ToString()
        {
            var code = FlagOfDisplay ? NumericCode.ToString() : Barcode;
            return $"Name:{Name}, Code:{code}";
        }

 
    }
    
}