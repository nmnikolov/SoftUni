using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stuck_Numbers
{
    public static class StuckNumbers
    {
        public static void Main()
        {
            bool found = false;
            Console.ReadLine();
            int n = 4;
            string[] arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            StringBuilder result = new StringBuilder();
            
            foreach (var comb in arr.GetPermutations(n))
            {
                var a = comb.ToArray();
                if (a[0] + a[1] == a[2] + a[3])
                {
                    found = true;
                    result.AppendFormat("{0}|{1}=={2}|{3}", a[0], a[1], a[2], a[3]).AppendLine();
                }
            }

            if (!found)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.Write(result);
            }
        }
    }

    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }    

        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] }
                          : elements.SelectMany(
                                (e, i) =>
                                  elements
                                  .Skip(i + 1)
                                  .GetCombinations(k - 1)
                                  .Select(c => (new[] { e }).Concat(c)));
        }
    }
}