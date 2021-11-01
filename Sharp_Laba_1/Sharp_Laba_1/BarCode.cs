using System;

namespace Sharp_Laba_1
{
    internal static class BarCode
    {
        public static string ToBarcode(int numericCode)
        {
            var bit = Convert.ToString(numericCode, 2);
            var barCode = "█";
            if (bit.Length % 2 != 0) bit = "0" + bit;
            for (var i = 0; i < bit.Length - 1; i += 2)
            {
                var tmp = bit.Substring(i, 2);
                switch (tmp)
                {
                    case "00":
                        barCode += " ";
                        break;
                    case "0":
                        barCode += " ";
                        break;
                    case "01":
                        barCode += "│";
                        break;
                    case "1":
                        barCode += "│";
                        break;
                    case "10":
                        barCode += "║";
                        break;
                    case "11":
                        barCode += "▌";
                        break;
                }
            }

            barCode += "█";
            return barCode;
        }

        public static int ToNumericCode(string barcode)
        {
            string bitCode = null;
            for (var i = barcode.Length - 1; i >= 0; i--)
            {
                switch (barcode[i])
                {
                    case ' ':
                        bitCode += "00";
                        break;
                    case '│':
                        bitCode += "01";
                        break;
                    case '║':
                        bitCode += "10";
                        break;
                    case '▌':
                        bitCode += "11";
                        break;
                    case '█':
                        return Convert.ToInt32(bitCode, 2);
                }
            }
            return Convert.ToInt32(bitCode, 2);
        }
        
        public static void GenerateFullBarcode(Product product, int storageNumcode, int indexOfProduct)
        {
            product.Barcode = ToBarcode(storageNumcode) + ToBarcode(indexOfProduct).Trim('█') + ToBarcode(product.NumericCode);
        }
    }
}
