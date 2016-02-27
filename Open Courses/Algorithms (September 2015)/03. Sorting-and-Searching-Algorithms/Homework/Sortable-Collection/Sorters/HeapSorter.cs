namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.HeapSort(collection);
        }

        public void HeapSort(List<T> x)
        {
            int i;
            int n = x.Count;

            for (i = (x.Count - 1) / 2; i >= 0; i--)
            {
                this.SiftDown(x, i, n - 1);
            }

            for (i = n - 1; i >= 1; i--)
            {
                var temp = x[0];
                x[0] = x[i];
                x[i] = temp;
                this.SiftDown(x, 0, i - 1);
            }
        }

        public void SiftDown(List<T> x, int root, int bottom)
        {
            bool done = false;
            int maxChild;

            while ((root * 2 <= bottom) && !done)
            {
                if (root * 2 == bottom)
                {
                    maxChild = root * 2;
                }
                else if (x[root * 2].CompareTo(x[root * 2 + 1]) > 0)
                {
                    maxChild = root * 2;
                }
                else
                {
                    maxChild = root * 2 + 1;
                }

                if (x[root].CompareTo(x[maxChild]) < 0)
                {
                    var temp = x[root];
                    x[root] = x[maxChild];
                    x[maxChild] = temp;
                    root = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }
    }
}
