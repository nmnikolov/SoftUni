namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; } = new List<T>();

        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            return this.BinarySearchProcedure(item, 0, this.Count - 1);
        }

        public int InterpolationSearch(T item)
        {
            int low = 0;
            int high = this.Items.Count - 1;
            int mid;

            if (high < low)
            {
                return -1;
            }

            while (this.Items[low].CompareTo(item) < 0 && this.Items[high].CompareTo(item) > 0)
            {
                mid = low + ((item.CompareTo(this.Items[low])) * (high - low)) / (this.Items[high].CompareTo(this.Items[low]));

                if (this.Items[mid].CompareTo(item) < 0)
                    low = mid + 1;
                else if (this.Items[mid].CompareTo(item) > 0)
                    high = mid - 1;
                else
                    return mid;
            }

            if (this.Items[low].CompareTo(item) == 0)
                return low;
            else
                return -1; // Not found
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }

        private int BinarySearchProcedure(T item, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return -1;
            }

            int midpoint = startIndex + (endIndex - startIndex) / 2;

            if (this.Items[midpoint].CompareTo(item) > 0)
            {
                return this.BinarySearchProcedure(item, startIndex, midpoint - 1);
            }

            if (this.Items[midpoint].CompareTo(item) < 0)
            {
                return this.BinarySearchProcedure(item, midpoint + 1, endIndex);
            }

            return midpoint;
        }
    }
}