using System.Collections;

namespace Sharp_Laba_1
{
    sealed class Comparers : Printer, IComparer
    {
        public Comparers(string name, int numericCode, int size, int speed, string format) : base(name, numericCode, size, speed, format)
        { }

        public int Compare(object x, object y)
        {
            throw new System.NotImplementedException();
        }
    }
}