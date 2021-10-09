using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp_Laba_1
{
    static class BarCode
    {
        public static string ToBarcode(int numericCode)
        {
            var bit = Convert.ToString(numericCode, 2);
            var barCode = "█";
            for (int i = 0; i < bit.Length - 1; i += 2)
            {
                var tmp = bit.Substring(i, 2);
                switch (tmp)
                {
                    case "00":
                        barCode += " ";
                        break;
                    case "01":
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
            for (var i = 1; i < barcode.Length - 1; i++)
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
                }
            }
            return Convert.ToInt32(bitCode, 2);
        }
    }
}
