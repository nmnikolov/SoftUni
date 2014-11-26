//using System;
//using System.Collections.Generic;
//using System.Linq;

//class BitsUp
//{
//    static void Main()
//    {
//        int n = int.Parse(Console.ReadLine());
//        int step = int.Parse(Console.ReadLine());
//        int currentBit = 0;
//        int position = 1;

//        for (int i = 0; i < n; i++)
//        {

//            string number = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
//            string[] num = number.Select(c => c.ToString()).ToArray();

//            for (int j = 0; j < 8; j++)
//            {
//                if (currentBit == position)
//                {
//                    num[j] = "1";
//                    position += step;
//                }
//                currentBit++;
//            }

//            int dec = 0;
//            for (int k = 0; k < 8; k++)
//            {
//                if (num[k] == "1")
//                {
//                    dec += (int)Math.Pow(2, 7 - k); 
//                }
//            }
//            Console.WriteLine(dec);            
//        }
//    }
//}