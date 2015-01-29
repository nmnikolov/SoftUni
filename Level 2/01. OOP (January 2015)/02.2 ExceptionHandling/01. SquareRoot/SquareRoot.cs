namespace SquareRoot
{
    using System;

    class SquareRoot
    {
        static void Main()
        {
            try
            {
                long number = long.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException("number", "Number cannot be negative");
                }

                Console.WriteLine("Square root: {0}", Math.Sqrt(number));
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Good bye.");
            }
        }
    }
}