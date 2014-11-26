using System;
using System.Collections.Generic;
using System.Linq;

class MagicCarNumbers
{
    static void Main()
    {
        int weight = int.Parse(Console.ReadLine());
        char[] letters = { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };
        int[] lettersWeight = { 10, 20, 30, 50, 80, 110, 130, 160, 200, 240 };
        string digits = "";
        int numberWeight = 0;
        int count = 0;

        for (int i0 = 0; i0 < 10; i0++)
        {
            for (int i1 = 0; i1 < 10; i1++)
            {
                for (int i2 = 0; i2 < 10; i2++)
                {
                    for (int i3 = 0; i3 < 10; i3++)
                    {                                              
                        if (ChechDigits(i0, i1, i2, i3))
                        {
                            for (int l1 = 0; l1 < 10; l1++)
                            {
                                for (int l2 = 0; l2 < 10; l2++)
                                {
                                    numberWeight = 0;
                                    string number = "CA" + i0 + i1 + i2 + i3 + letters[l1] + letters[l2];
                                    numberWeight += 40 + i0 + i1 + i2 + i3 + lettersWeight[l1] + lettersWeight[l2];
                                    if (numberWeight == weight)
                                    {
                                        count++;
                                    }
                                }
                            }
                        }                                               
                    }
                }
            }
        }
        Console.WriteLine(count);  
    }

    public static bool ChechDigits(int i0, int i1, int i2, int i3)
    {
        List<int> input = new List<int>() { i0, i1, i2, i3 };
        input = input.Distinct().ToList();
        bool ret = false;
        bool a = input.Count == 1;
        bool b = false;
        bool c = false;
        bool d = false;
        bool e = false;
        bool f = false;
        if (input.Count == 2)
        {
            b = i0 != i1 && i1 == i2 && i2 == i3;
            c = i0 == i1 && i1 == i2 && i0 != i3;
            d = i0 == i1 && i0 != i2 && i0 != i3;
            e = i0 == i2 && i0 != i1 && i0 != i3;
            f = i0 == i3 && i0 != i1 && i0 != i2;
        }
        if (a || b || c || d || e || f)
        {
            ret = true;
        }
        return ret;
    }
}