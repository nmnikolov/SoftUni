namespace GenericList
{
    using System;
    using System.Text;

    [Version(1.00)]
    public class GenericList<T>
        where T : IComparable<T>
    {
        const byte Capacity = 16;
        
        public GenericList(int capacity = Capacity)
        {
            this.Elements = new T[capacity];
            this.Count = 0;
        }

        public T[] Elements { get; set; }

        public int Count { get; private set; }

        public void Add(T value)
        {
            if (this.Count == this.Elements.Length)
            {
                T[] newList = new T[this.Elements.Length * 2];
                for (int i = 0; i < this.Count; i++)
                {
                    newList[i] = this.Elements[i];
                }
                this.Elements = newList;
            }

            this.Elements[this.Count] = value;
            this.Count++;
        }

        public T ElementAt(int index)
        {
            this.IndexValidation(index);

            return this.Elements[index];
        }

        public void RemoveAt(int index)
        {
            T[] newList = new T[this.Elements.Length];
            for (int i = 0, position = 0; i < this.Count; i++, position++)
            {
                if (i != index)
                {
                    newList[position] = this.Elements[i];
                    continue;
                }
                
                position--;
            }

            this.Elements = newList;
            this.Count--;
        }

        public void InsertAt(int index, T value)
        {
            if (index >= this.Count)
            {
                this.Add(value);
            }
            else
            {
                this.IndexValidation(index);
                this.Elements[index] = value;
            }
        }

        public void Clear()
        {
            this.Elements = new T[this.Elements.Length];
            this.Count = 0;
        }

        public T Max()
        {
            var max = this.Elements[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (max.CompareTo(this.Elements[i]) < 0)
                {
                    max = this.Elements[i];
                }
            }

            return max;
        }

        public T Min()
        {
            var min = this.Elements[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (min.CompareTo(this.Elements[i]) > 0)
                {
                    min = this.Elements[i];
                }
            }

            return min;
        }

        public int? FindElementIndex(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Elements[i].Equals(element))
                {
                    return i;
                }
            }

            return null;
        }

        public bool Countains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Elements[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        private void IndexValidation(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                result.AppendFormat("{0}: {1}\n", i, this.Elements[i]);
            }

            return result.ToString();
        }
    }
}