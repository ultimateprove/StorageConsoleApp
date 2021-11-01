using static Sharp_Laba_1.BarCode;

namespace Sharp_Laba_1
{
    /// <summary>
    /// Класс продукции
    /// </summary>
    public abstract class Product
    {
        private int _numericCode;
        private string _barcode;

        public int NumericCode
        {
            get => _numericCode;
            set
            {
                _numericCode = value;
                _barcode = ToBarcode(_numericCode);
            }
        }

        public string Barcode
        {
            get => _barcode;
            set
            {
                _barcode = value;
                _numericCode = ToNumericCode(_barcode);
            }
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