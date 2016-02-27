namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(List<T> array, int start, int end)
        {
            if (start < end)
            {
                int middle = (end + start) / 2;
                this.MergeSort(array, start, middle);
                this.MergeSort(array, middle + 1, end);
                this.Merge(array, start, middle, middle + 1, end);
            }
        }
        
        private void Merge(List<T> x, int left, int middle, int middle1, int right)
        {
            int oldPosition = left;
            int size = right - left + 1;
            T[] temp = new T[x.Count];
            int i = 0;

            while (left <= middle && middle1 <= right)
            {
                if (x[left].CompareTo(x[middle1]) <= 0)
                {
                    temp[i++] = x[left++];
                }
                else
                {
                    temp[i++] = x[middle1++];
                }
            }
            if (left > middle)
            {
                for (int j = middle1; j <= right; j++)
                {
                    temp[i++] = x[middle1++];
                }
            }
            else
            {
                for (int j = left; j <= middle; j++)
                {
                    temp[i++] = x[left++];
                }
            }

            for (int j = 0; j < size; j++)
            {
                x[oldPosition + j] = temp[j];
            }
        }
    }
}