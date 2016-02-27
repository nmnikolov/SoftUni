using System;
using System.Linq;

namespace SieveOfEratosthenes
{
    public class SieveOfEratosthenes
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool[] e = new bool[n + 1];//by default they're all false
            for (int i = 2; i <= n; i++)
            {
                e[i] = true;//set all numbers to true
            }
            //weed out the non primes by finding mutiples 
            for (int j = 2; j <= n; j++)
            {
                if (e[j])//is true
                {
                    for (long p = 2; (p * j) <= n; p++)
                    {
                        e[p * j] = false;
                    }
                }
            }

            string a = "";

            for (int i = 2; i < e.Length; i++)
            {
                if (e[i])
                {
                    a += i + ", ";
                }
            }

            Console.WriteLine(a.Substring(0, a.Length - 2));
        }
    }
}