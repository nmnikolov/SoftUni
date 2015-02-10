namespace FractionCalculator
{
    using System;
    using System.Numerics;

    public struct Fraction
    {
        private BigInteger numerator;

        private BigInteger denominator;

        public Fraction(BigInteger numerator, BigInteger denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public BigInteger Numerator {
            get { return this.numerator; }
            private set
            {
                if (value < -9223372036854775808 || value > 9223372036854775808)
                {
                    throw new ArgumentOutOfRangeException("numerator", "Numerator should be in the range [-9223372036854775808...223372036854775807].");
                }

                this.numerator = value;
            } 
        }

        public BigInteger Denominator
        { 
            get { return this.denominator; }
            private set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denominator cannot be 0.");
                }

                if (value <-9223372036854775808 || value > 9223372036854775808)
                {
                    throw new ArgumentOutOfRangeException("denominator", "Denominator should be in the range [-9223372036854775808...9223372036854775807].");
                }

                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            BigInteger numerator = fraction1.Numerator * fraction2.Denominator + fraction2.Numerator * fraction1.Denominator;
            BigInteger denominator = fraction1.Denominator * fraction2.Denominator;
        
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            BigInteger numerator = fraction1.Numerator * fraction2.Denominator - fraction2.Numerator * fraction1.Denominator;
            BigInteger denominator = fraction1.Denominator * fraction2.Denominator;

            return new Fraction(numerator, denominator);
        }

        public override string ToString()
        {
            String result = String.Format("{0}", (decimal)this.Numerator / (decimal)this.Denominator);

            return result;
        }
    }
}