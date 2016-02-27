namespace ArraySubset
{
    using System;
    using System.Linq;

    public class AllSubSetOfSizeK
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter array elemens separated by \", \"");
            var arr = Console.ReadLine().Split(new [] {", "}, StringSplitOptions.RemoveEmptyEntries);

            Console.Write("Enter k elements to print: ");
            var k = int.Parse(Console.ReadLine());

            var used = new Boolean[arr.Length];

            Subset(arr, k, 0, 0, used);
        }

        public static void Subset(string[] arr, int k, int start, int currLen, Boolean[] used)
        {
            if (currLen == k)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (used[i])
                    {
                        Console.Write(arr[i] + " ");
                    }
                }
                Console.WriteLine();
                return;
            }
            if (start == arr.Length)
            {
                return;
            }
            used[start] = true;
            Subset(arr, k, start + 1, currLen + 1, used);
            used[start] = false;
            Subset(arr, k, start + 1, currLen, used);
        }
    }
}