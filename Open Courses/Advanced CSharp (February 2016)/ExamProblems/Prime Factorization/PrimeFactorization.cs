using System;
using System.Collections.Generic;

namespace PrimeFactorization
{
    public class PrimeFactorization
    {
        private static int initialNumber;

        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            initialNumber = number;

            var factors = new List<long>();
            var maxFactor = 0;
            

            while (number > 1)
            {
                var nextFactor = 2;
                if (number % nextFactor > 0)
                {
                    nextFactor = 3;
                    do
                    {
                        if (number % nextFactor == 0)
                        {
                            break;
                        }

                        nextFactor += 2;
                    } while (nextFactor < number);
                }

                number /= nextFactor;
                factors.Add(nextFactor);
                if (nextFactor > maxFactor)
                {
                    maxFactor = nextFactor;
                }
            }

            Console.WriteLine("{0} = {1}", initialNumber, string.Join(" * ", factors));
        }
    }
}