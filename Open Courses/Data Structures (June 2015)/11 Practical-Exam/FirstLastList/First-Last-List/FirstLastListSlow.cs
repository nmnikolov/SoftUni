using System;
using System.Collections.Generic;
using System.Linq;

public class FirstLastListSlow<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private List<T> elements = new List<T>();

    public void Add(T newElement)
    {
        this.elements.Add(newElement);
    }

    public int Count
    {
        get { return this.elements.Count; }
    }

    public IEnumerable<T> First(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.elements.Take(count);
    }

    public IEnumerable<T> Last(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.elements.Skip(this.Count - count).Reverse().Take(count);
    }

    public IEnumerable<T> Min(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        var temp = this.elements.OrderBy(e => e)
            .Take(count);

        return temp;
    }

    public IEnumerable<T> Max(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        var temp = this.elements.OrderByDescending(e => e)
            .Take(count);

        return temp;
    }

    public int RemoveAll(T element)
    {
        return this.elements.RemoveAll(e => e.CompareTo(element) == 0);
    }

    public void Clear()
    {
        this.elements.Clear();
    }
}
