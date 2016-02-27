using System;
using System.Collections.Generic;
using System.Linq;

namespace Pythagorean_Numbers
{
    public class PythagoreanNumbers
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int[] numbers = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            var perms = numbers.GetCombinationsRepetition(3);

            foreach (var perm in perms)
            {
                //Console.WriteLine(string.Join(" ", perm));

                var comb = perm.ToArray();

                int firstNumber = comb[0];
                int secondNumber = comb[1];
                int thirdNumber = comb[2];

                if (firstNumber * firstNumber + secondNumber * secondNumber == thirdNumber * thirdNumber)
                {
                    Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", firstNumber, secondNumber, thirdNumber);
                }
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
            return k == 0 ? new[] { new T[0] }
                          : elements.SelectMany(
                                (e, i) =>
                                  elements
                                  .GetCombinations(k - 1)
                                  .Select(c => (new[] { e }).Concat(c)));
        }
    }
}