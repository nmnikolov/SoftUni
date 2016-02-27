using System;
using System.Linq;

namespace BinarySearch
{
    public class BinarySearch
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(e => e).ToList();
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine(numbers.IndexOf(number));
        }
    }
}