using System;
using System.Collections.Generic;
using System.Linq;

class BullsAndCows
{
    static void Main()
    {
        string num = Console.ReadLine();
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        List<int> numList = new List<int>();
        List<int> guessList = new List<int>();     

        string output = "";
        int count = 0;

        for (int i1 = 1; i1 <= 9; i1++)
        {          
            for (int i2 = 1; i2 <= 9; i2++)
            {
                for (int i3 = 1; i3 <= 9; i3++)
                {
                    for (int i4 = 1; i4 <= 9; i4++)
                    {
                        int bulls = 0;
                        int cows = 0;
                        string guess = "" + i1 + i2 + i3 + i4;

                        for (int t = 0; t < 4; t++)
                        {
                            numList.Add(num[t]);
                            guessList.Add(guess[t]);
                        }

                        for (int i = 3; i >=0; i--)
                        {
                            if (guess[i] == num[i])
                            {
                                bulls++;
                                numList.RemoveAt(i);
                                guessList.RemoveAt(i);
                                
                            }                      
                        }

                        for (int k = 0; k < guessList.Count; k++)
                        {
                            if (numList.Contains(guessList[k]))
                            {
                                cows++;
                                numList.Remove(guessList[k]);
                            }
                        }

                        if (bulls == b && cows == c)
                        {
                            output += guess + " ";
                            count++;
                        }

                        numList.Clear();
                        guessList.Clear();
                    }
                }
            }
        }

        if (count == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(output.Trim());
        }
    }
}