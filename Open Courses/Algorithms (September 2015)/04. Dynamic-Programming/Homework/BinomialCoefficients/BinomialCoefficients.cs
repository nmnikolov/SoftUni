namespace BinomialCoefficients
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Numerics;

    public class BinomialCoefficients
    {
        public static void Main()
        {
            var n = 10000;
            var k = 5000;
            
            var timer = new Stopwatch();

            timer.Start();
            var resultMem = BinomialCoefficientMemoization(n, k);
            timer.Stop();
            var timeMemoization = timer.Elapsed;

            timer.Restart();
            var resultFast = BinomialCoefficientFast(n, k);
            timer.Stop();
            var timeFast = timer.Elapsed;

            //timer.Restart();
            //var resultRecursion = BinomialCoefficientRecursion(n, k);
            //timer.Stop();
            //var timeRecursion = timer.Elapsed;

            Console.WriteLine("Memoization: {0}", resultMem);
            Console.WriteLine("Time: {0}", timeMemoization);

            Console.WriteLine("Fast: {0}", resultFast);
            Console.WriteLine("Time: {0}", timeFast);

            //Console.WriteLine("Recursion: {0}", resultRecursion);
            //Console.WriteLine("Time: {0}", timeRecursion);
        }

        private static BigInteger BinomialCoefficientMemoization(int n, int k)
        {
            var mem = new BigInteger[k + 1];
            mem[0] = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = Math.Min(i, k); j > 0; j--)
                {
                    mem[j] = mem[j] + mem[j - 1];
                }
            }

            return mem[k];
        }

        private static BigInteger BinomialCoefficientFast(int n, int k)
        {
            if (k < 0 || k > n)
            {
                return 0;
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            k = Math.Min(k, n - k);
            BigInteger c = 1;

            for (int i = 0; i < k; i++)
            {
                c = c*(n - i)/(i + 1);
            }

            return c;
        }

        private static BigInteger BinomialCoefficientRecursion(int n, int k)
        {
            if (k < 0 || k > n)
            {
                return 0;
            }

            if (k > n - k)
            {
                k = n - k;
            }

            if (k == 0 || n <= 1)
            {
                return 1;
            }
            
            return BinomialCoefficientRecursion(n - 1, k) + BinomialCoefficientRecursion(n - 1, k - 1);
        }
    }
}