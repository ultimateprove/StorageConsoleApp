namespace Sharp_Laba_1
{
    public class Printer : Product, IPrinter
    {
        public int Size { get; set; }
        
        public int Speed { get; set; }

        public string Format { get; set; }
        
        public Printer(string name, int numericCode, int size, int speed, string format) : base(name, numericCode)
        {
            Size = size;
            Speed = speed;
            Format = format;
        }
        
        public override string ToString()
        {
            return $"{base.ToString()} Size:{Size}, Speed:{Speed}, Format:{Format}";
        }
    }
}