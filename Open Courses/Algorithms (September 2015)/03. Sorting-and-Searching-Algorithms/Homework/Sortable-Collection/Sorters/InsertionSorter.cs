namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Contracts;

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
}
