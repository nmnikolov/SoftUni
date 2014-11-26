using System;
using System.Collections.Generic;
using System.Linq;

class FiveSpecialLetters
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        char[] letters = { 'a', 'b', 'c', 'd', 'e' };
        int[] lettersWeight = { 5, -12, 47, 7, -32};
        List<char> match = new List<char>();
        string output = "";
        int count = 0;

        for (int i1 = 0; i1 < letters.Length; i1++)
        {
            for (int i2 = 0; i2 < letters.Length; i2++)
            {
                for (int i3 = 0; i3 < letters.Length; i3++)
                {
                    for (int i4 = 0; i4 < letters.Length; i4++)
                    {
                        for (int i5 = 0; i5 < letters.Length; i5++)
                        {
                            int weight = 0;
                            match.Add(letters[i1]);
                            match.Add(letters[i2]);
                            match.Add(letters[i3]);
                            match.Add(letters[i4]);
                            match.Add(letters[i5]);
                            match = match.Distinct().ToList();

                            for (int i = 0; i < match.Count; i++)
                            {
                                switch (match[i])
	                            {
                                    case 'a':
                                        weight += (i + 1) * lettersWeight[0]; break;
                                    case 'b':
                                        weight += (i + 1) * lettersWeight[1]; break;
                                    case 'c':
                                        weight += (i + 1) * lettersWeight[2]; break;
                                    case 'd':
                                        weight += (i + 1) * lettersWeight[3]; break;
                                    case 'e':
                                        weight += (i + 1) * lettersWeight[4]; break;
	                            }
                            }

                            if (weight >= start && weight <= end)
                            {
                                output += "" + letters[i1] + letters[i2] + letters[i3] + letters[i4] + letters[i5] + " ";
                                count++;
                            }

                            match.Clear();
                        }
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