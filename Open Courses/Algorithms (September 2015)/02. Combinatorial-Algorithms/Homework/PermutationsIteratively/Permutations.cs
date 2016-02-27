namespace PermutationsIteratively
{
    using System;
    using System.Linq;

    public class Permutations
    {
        private static int countOfPermutations = 1;

        public static void Main()
        {
            Console.Write("Input N: ");
            int n = int.Parse(Console.ReadLine());
            int key = n - 1;

            var currentPermutation = Enumerable.Range(1, n).ToArray();
            Console.WriteLine(string.Join(", ", currentPermutation));
            key = FindKey(currentPermutation);

            while (key >= 0)
            {
                SwapKey(currentPermutation, key);
                Array.Sort(currentPermutation, key + 1, n - key - 1);
                Console.WriteLine(string.Join(", ", currentPermutation));
                countOfPermutations++;

                key = FindKey(currentPermutation);
            }

            Console.WriteLine("Total permurations: {0}", countOfPermutations);
        }

        private static void SwapKey(int[] arr, int key)
        {
            for (int i = arr.Length - 1; i >= key; i--)
            {
                if (arr[i] > arr[key])
                {
                    var tempNum = arr[key];
                    arr[key] = arr[i];
                    arr[i] = tempNum;
                    return;
                }
            }
        }

        private static int FindKey(int[] currentPerm)
        {
            for (int i = currentPerm.Length - 2; i >= 0; i--)
            {
                if (currentPerm[i] < currentPerm[i + 1]) return i;
            }
            return -1;
        }
    }
}