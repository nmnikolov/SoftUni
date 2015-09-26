using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private readonly LinkedList<T> elements = new LinkedList<T>();
    private readonly OrderedBag<T> orderedBag = new OrderedBag<T>();
    private readonly OrderedBag<T> reversedOrderedBag = new OrderedBag<T>((x, y) => -x.CompareTo(y));
    private readonly OrderedDictionary<T, List<LinkedListNode<T>>> duplicateElements = new OrderedDictionary<T, List<LinkedListNode<T>>>();

    public void Add(T newElement)
    {
        var node = this.elements.AddLast(newElement);
        this.orderedBag.Add(newElement);
        this.reversedOrderedBag.Add(newElement);
        if (!this.duplicateElements.ContainsKey(newElement))
        {
            this.duplicateElements.Add(newElement, new List<LinkedListNode<T>>());
        }
        this.duplicateElements[newElement].Add(node);
    }

    public int Count
    {
        get { return this.orderedBag.Count; }
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

        return this.elements.Skip(this.Count - count).Take(count).Reverse();
    }

    public IEnumerable<T> Min(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.orderedBag.Take(count);
    }

    public IEnumerable<T> Max(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.reversedOrderedBag.Take(count);
    }

    public int RemoveAll(T element)
    {
        List<LinkedListNode<T>> elementsToRemove;
        this.duplicateElements.TryGetValue(element, out elementsToRemove);
        if (elementsToRemove == null)
        {
            return 0;
        }

        var totalElements = elementsToRemove.Count;
        foreach (var elementToRemove in elementsToRemove)
        {
            this.elements.Remove(elementToRemove);
        }

        this.orderedBag.RemoveAllCopies(element);
        this.reversedOrderedBag.RemoveAllCopies(element);
        this.duplicateElements[element].Clear();

        return totalElements;
    }

    public void Clear()
    {
        this.elements.Clear();
        this.duplicateElements.Clear();
        this.orderedBag.Clear();
        this.reversedOrderedBag.Clear();
    }
}