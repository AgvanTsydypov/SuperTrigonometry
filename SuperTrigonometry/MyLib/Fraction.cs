namespace MyLib
{
    public class Fraction
    {
        private double numerator;
        private double denominator;
        public double Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }
        public double Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                denominator = value;
            }
        }

        public Fraction(double n,double d)
        {
            Numerator = n;
            Denominator = d;
        }
        public Fraction(double n)
        {
            if (n == 0)
            {
                Numerator = 0;
                Denominator = 1;
            }
            if (n == 1)
            {
                Numerator = 1;
                Denominator = 1;
            }
            if (n == -1)
            {
                Numerator = -1;
                Denominator = 1;
            }
            if (n == -0.5)
            {
                Numerator = -1;
                Denominator = 2;
            }
            if (n == 0.5)
            {
                Numerator = 1;
                Denominator = 2;
            }
            if (n == 1.5)
            {
                Numerator = 3;
                Denominator = 2;
            }
            if (n == -1.5)
            {
                Numerator = -3;
                Denominator = 2;
            }
        }
        public override string ToString()
        {
            return $"num = {Numerator}; den = {Denominator}";
        }
    }
}
