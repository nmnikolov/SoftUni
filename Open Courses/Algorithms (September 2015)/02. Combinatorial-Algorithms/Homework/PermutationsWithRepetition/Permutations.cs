namespace PermutationsWithRepetition
{
    using System;
    using System.Linq;

    public class Permutations
    {
        private static int countOfPermutations = 1;

        public static void Main()
        {
            var arr = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(e => e)
                .ToArray();

            Console.WriteLine(new string('-', 70));
            Console.WriteLine(string.Join(", ", arr));
            Permute(arr, 0, arr.Length);

            Console.WriteLine("Total permurations: {0}", countOfPermutations);
        }

        public static void Permute(int[] ps, int start, int n)
        {
            if (start < n)
            {
                for (var i = n - 2; i >= start; i--)
                {
                    int temp;

                    for (var j = i + 1; j < n; j++)
                    {
                        if (ps[i] != ps[j])
                        {
                            temp = ps[i];
                            ps[i] = ps[j];
                            ps[j] = temp;

                            Console.WriteLine(string.Join(", ", ps));
                            countOfPermutations++;
                            Permute(ps, i + 1, n);
                        }
                    }

                    temp = ps[i];
                    for (var k = i; k < n - 1;)
                    {
                        ps[k] = ps[++k];
                    }

                    ps[n - 1] = temp;
                }
            }
        }
    }
}