//using System;
//using System.Collections.Generic;
//using System.Linq;

//class BitsInverterArrays
//{
//    static void Main()
//    {
//        int n = int.Parse(Console.ReadLine());
//        int step = int.Parse(Console.ReadLine());
//        int position = 0;
//        int convert = 0;

//        for (int i = 0; i < n; i++)
//        {
//            string number = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
//            string[] num = number.Select(c => c.ToString()).ToArray();

//            for (int j = 0; j < 8; j++)
//            {
//                if (position == convert)
//                {
//                    if (num[j] == "0")
//                    {
//                        num[j] = "1";
//                    }
//                    else
//                    {
//                        num[j] = "0";
//                    }
//                    convert += step;
//                }
//                position ++;
//            }

//            int dec = 0;

//            for (int k = 0; k < 8; k++)
//            {
//                if (num[num.Length - k - 1] == "1")
//                {
//                    dec += (int)Math.Pow(2, k);
//                }
//            }

//            Console.WriteLine(dec);
//        }
//    }
//}