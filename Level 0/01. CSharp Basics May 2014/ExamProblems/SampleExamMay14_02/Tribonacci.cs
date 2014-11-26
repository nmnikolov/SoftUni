using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        BigInteger T1 = int.Parse(Console.ReadLine());
        BigInteger T2 = int.Parse(Console.ReadLine());
        BigInteger T3 = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        BigInteger Tn = 0;

        if (n == 1)
        {
            Console.WriteLine(T1);
        }
        else if (n == 2)
        {
            Console.WriteLine(T2);
        }
        else
        {
            for (int i = 4; i <= n; i++)
            {
                Tn = T1 + T2 + T3;
                T1 = T2;
                T2 = T3;
                T3 = Tn;
            }
            Console.WriteLine(T3);
        }      
    }
}