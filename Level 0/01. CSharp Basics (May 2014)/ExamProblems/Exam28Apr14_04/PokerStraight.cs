using System;

class PokerStraigh
{
    static void Main()
    {
        int w = int.Parse(Console.ReadLine());
        int[] facesWeight = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        int[] suitsWeight = { 1, 2, 3, 4 };
        int weight = 0;
        int count = 0;

        for (int i1 = 0; i1 < facesWeight.Length - 4; i1++)
        {
            for (int i2 = 0; i2 < suitsWeight.Length; i2++)
            {
                for (int i3 = 0; i3 < suitsWeight.Length; i3++)
                {
                    for (int i4 = 0; i4 < suitsWeight.Length; i4++)
                    {
                        for (int i5 = 0; i5 < suitsWeight.Length; i5++)
                        {
                            for (int i6 = 0; i6 < suitsWeight.Length; i6++)
                            {
                                weight = 10 * facesWeight[i1] + suitsWeight[i2] +
                                         20 * facesWeight[i1 + 1] + suitsWeight[i3] +
                                         30 * facesWeight[i1 + 2] + suitsWeight[i4] +
                                         40 * facesWeight[i1 + 3] + suitsWeight[i5] +
                                         50 * facesWeight[i1 + 4] + suitsWeight[i6];
                                if (weight == w)
                                {
                                    count++;
                                }
                            }
                        }                        
                    }
                }
            }
        }
        Console.WriteLine(count);
    }
}
