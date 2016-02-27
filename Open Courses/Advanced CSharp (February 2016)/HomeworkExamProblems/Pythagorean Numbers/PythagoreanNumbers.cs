using System;
using System.Collections.Generic;
using System.Linq;

namespace Pythagorean_Numbers
{
    public class PythagoreanNumbers
    {
        public static void Main()
        {
            bool found = false;
            int rows = int.Parse(Console.ReadLine());
            int[] numbers = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            IEnumerable<IEnumerable<int>> perms = numbers.GetCombinationsRepetition(3);
                        
            foreach (var perm in perms)
            {
                var comb = perm.ToArray();

                int max = comb.Max();
                int min = comb.Min();
                int middle = comb.Sum() - max - min;

                if (min * min + middle * middle == max * max)
                {
                    found = true;
                    Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", min, middle, max);
                }
            }

            if (!found)
            {
                Console.WriteLine("No");
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

        public static IEnumerable<IEnumerable<T>> GetPermutationsRepetition<T>(this IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutationsRepetition(list, length - 1)
                .SelectMany(t => list.Where(o => 1 == 1),
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

        public static IEnumerable<IEnumerable<T>> GetCombinationsRepetition<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } : elements.SelectMany(
                                (e, i) =>
                                  elements
                                  .Skip(i)
                                  .GetCombinationsRepetition(k - 1)
                                  .Select(c => (new[] { e }).Concat(c)));
        }
    }
}