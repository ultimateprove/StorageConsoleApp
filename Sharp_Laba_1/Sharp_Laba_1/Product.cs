using static Sharp_Laba_1.BarCode;

namespace Sharp_Laba_1
{
    /// <summary>
    /// Класс продукции
    /// </summary>
    public abstract class Product : IProduct
    {
        private int _numericCode; // Числовой код
        private string _barcode; // Штрихкод

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

        /// <summary>
        /// Название продукта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Флагб выводить штрихкод или числовой
        /// </summary>
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