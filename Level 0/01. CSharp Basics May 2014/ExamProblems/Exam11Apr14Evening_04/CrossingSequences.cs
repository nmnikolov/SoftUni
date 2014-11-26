using System;

class CrossingSequences
{
    static void Main()
    {
        int t1 = int.Parse(Console.ReadLine());
        int t2 = int.Parse(Console.ReadLine());
        int t3 = int.Parse(Console.ReadLine());
        int startNum = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        int power = 1;
        bool increasePower = false;

        while (t3 <= 1000000)
        {          
            while (startNum <= Math.Max(Math.Max(t1, t2), t3))
            {
                if (startNum == t3 || startNum == t2 || startNum == t1)
                {
                    Console.WriteLine(startNum);
                    return;
                }
                startNum += step * power;
                if (increasePower)
                {
                    power++;
                }
                increasePower = !increasePower;               
            }

            int tN = t3 + t2 + t1;
            t1 = t2;
            t2 = t3;
            t3 = tN;
        }
        Console.WriteLine("No");
    }
}