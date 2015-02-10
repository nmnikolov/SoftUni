namespace FractionCalculator
{
    using System;

    public class FractionCalculator
    {
        public static void Main()
        {
            try
            {
                Fraction fraction1 = new Fraction(9223372036854775807, 7);
                Fraction fraction2 = new Fraction(9223372036854775807, 4);
                Fraction result = fraction1 + fraction2;
                Console.WriteLine(result.Numerator);
                Console.WriteLine(result.Denominator);
                Console.WriteLine(result);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}