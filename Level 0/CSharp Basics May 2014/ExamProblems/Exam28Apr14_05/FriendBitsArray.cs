//using System;
//using System.Collections.Generic;
//using System.Linq;

//class FriendBitsArray
//{
//    static void Main()
//    {
//        uint n = UInt32.Parse(Console.ReadLine());
//        char[] number = Convert.ToString(n, 2).ToArray();
//        string friendBits = "";
//        string aloneBits = "";

//        if (n == 0)
//        {
//            Console.WriteLine("0\n0");
//            return;
//        }

//        for (int i = 0; i < number.Length; i++)
//        {
//            if (i == 0)
//            {
//                if (number[i] == number[i+1])
//                {
//                    friendBits += number[i];
//                }
//                else
//                {
//                    aloneBits += number[i];
//                }
//            }
//            else if (i == number.Length - 1)
//            {
//               if (number[i] == number[i-1])
//                {
//                    friendBits += number[i];
//                }
//                else
//                {
//                    aloneBits += number[i];
//                } 
//            }
//            else
//            {
//                if (number[i] == number[i-1] || number[i] == number[i+1])
//                {
//                    friendBits += number[i];
//                }
//                else
//                {
//                    aloneBits += number[i];
//                }
//            }

//        }

//        Console.WriteLine(ConvertToDec(friendBits));
//        Console.WriteLine(ConvertToDec(aloneBits));
//    }

//    public static uint ConvertToDec (string s)
//    {
//        uint dec = 0;
//        for (int i = 0; i < s.Length; i++)
//        {
//            if (s[s.Length - i - 1] == '1')
//            {
//                dec += (uint)Math.Pow(2, i);
//            }
//        }
//        return dec;
//    }
//}