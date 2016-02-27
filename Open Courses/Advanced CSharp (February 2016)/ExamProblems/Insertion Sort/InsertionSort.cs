using System;
using System.Collections.Generic;
using System.Linq;

namespace InsertionSort
{
    public class InsertionSort
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(e => e).ToList();
            InsertionSorter<int> sorter = new InsertionSorter<int>();
            sorter.Sort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                int targetIndex = i;

                while (targetIndex > 0)
                {
                    if (collection[targetIndex - 1].CompareTo(collection[targetIndex]) > 0)
                    {
                        var temp = collection[targetIndex - 1];
                        collection[targetIndex - 1] = collection[targetIndex];
                        collection[targetIndex] = temp;

                    }

                    targetIndex--;
                }
            }
        }
    }

    public interface ISorter<T> where T : IComparable<T>
    {
        void Sort(List<T> collection);
    }
}