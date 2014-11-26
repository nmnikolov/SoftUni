using System;
using System.Collections.Generic;
using System.Linq;

class MagicStrings
{
    static void Main()
    {
        int diff = int.Parse(Console.ReadLine());
        char[] letters = { 's', 'n', 'k', 'p' };
        int[] weight = { 3, 4, 1, 5 };
        List<string> output = new List<string>();


        for (int i1 = 0; i1 < 4; i1++)
        {
            for (int i2 = 0; i2 < 4; i2++)
            {
                for (int i3 = 0; i3 < 4; i3++)
                {
                    for (int i4 = 0; i4 < 4; i4++)
                    {
                        for (int i5 = 0; i5 < 4; i5++)
                        {
                            for (int i6 = 0; i6 < 4; i6++)
                            {
                                for (int i7 = 0; i7 < 4; i7++)
                                {
                                    for (int i8 = 0; i8 < 4; i8++)
                                    {
                                        int sum1 = weight[i1] + weight[i2] + weight[i3] + weight[i4];
                                        int sum2 = weight[i5] + weight[i6] + weight[i7] + weight[i8];
                                        if (Math.Abs(sum2 - sum1) == diff)
                                        {
                                            string let = "" + letters[i1] + letters[i2] + letters[i3] + letters[i4] +
                                                            letters[i5] + letters[i6] + letters[i7] + letters[i8];
                                            output.Add(let);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        if (output.Count == 0)
        {
            Console.WriteLine("No");
            return;
        }

        output.Sort();
        foreach (string s in output)
        {
            Console.WriteLine(s);
        }
    }
}