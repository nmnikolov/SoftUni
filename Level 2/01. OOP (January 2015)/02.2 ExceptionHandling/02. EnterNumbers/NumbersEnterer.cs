namespace Numbers
{
    using System;
    using System.Linq;

    public class NumbersEnterer
    {
        public static void Main()
        {
            int[] userNumbers = new int[10];

            for (int i = 0; i < 10; i++)
            {
                int start = Math.Max(1, userNumbers.Max());
                int end = 91 + i;
                userNumbers[i] = ReadNumber(start, end);
            }

            Console.WriteLine("\nEntered numbers:");
            for (int i = 0; i < userNumbers.Length; i++)
            {
                Console.WriteLine("Number[{0}]: {1}", i + 1, userNumbers[i]);
            }
        }

        public static int ReadNumber(int start, int end)
        {
            try
            {
                Console.Write("Enter number [{0}...{1}]: ", start + 1, end - 1);
                int number = int.Parse(Console.ReadLine());
                if (number <= start || number >= end)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("You should enter integer number. Try again:");

                return ReadNumber(start, end);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Number should be in the range [{0}...{1}]. Try again:", start + 1, end - 1);

                return ReadNumber(start, end);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message + " Try again:");

                return ReadNumber(start, end);
            }
        }
    }
}