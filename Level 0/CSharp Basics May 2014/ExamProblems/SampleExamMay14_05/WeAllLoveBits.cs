using System;

class WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int p = int.Parse(Console.ReadLine());
            int pInversed = 0;
            int tempNum = p;

            while (tempNum > 0)
	        {
                pInversed = (pInversed << 1) | (tempNum & 1);
                tempNum >>= 1;	         
	        }

            p = (p ^ ~p) & pInversed;
            Console.WriteLine(p);
        }
    }
}