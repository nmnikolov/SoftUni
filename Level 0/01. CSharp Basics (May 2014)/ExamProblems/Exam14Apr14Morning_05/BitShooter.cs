using System;

class BitShooter
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        ulong countLeft = 0;
        ulong countRight = 0;
        bool right = true;

        for (int i = 0; i < 3; i++)
        {
            string[] shoot = Console.ReadLine().Split(' ');
            int center = int.Parse(shoot[0]);
            int size = int.Parse(shoot[1]);

            n = n & ~((ulong)1 << center);

            for (int i1 = 1; i1 <= size / 2; i1++)  //Change left
            {
                if (center + i1 > 63)
                {
                    break;
                }
                n = n & ~((ulong)1 << (center + i1));
            }

            for (int i2 = 1; i2 <= size / 2; i2++) // Change right
            {
                if (center - i2 < 0)
                {
                    break;
                }
                n = n & ~((ulong)1 << (center - i2));
            }      
        }

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 32; j++)
            {                             
                if ((n & (int)1) == 1 && right == true)
                {
                    countRight++;
                }
                else if ((n & (int)1) == 1)
                {
                    countLeft++;
                }
                n = n >> 1;
            }
            right = false;
        }
        Console.WriteLine("left: {0}\nright: {1}", countLeft, countRight);
    }
}