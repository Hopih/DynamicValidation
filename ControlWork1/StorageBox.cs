namespace ControlWork1;
using System;
using System.Collections.Generic;
using System.Collections;
public class StorageBox<T> : IEnumerable<T> where  T : Package
{
    private List<T> box = new List<T>();
    public void Add(T item)
    {
        box.Add(item);
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return box.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<Package> GetAvailableFragilePackages()
    {
        foreach (var item in box)
        {
            if (item is Package && item.IsFragile && item.Weight<=10 && item.ExpirationDate >= DateTime.Today)
            {
                yield return item;
            }
        }
    }

    public static T FindMax<T>(IEnumerable<T> items) where T : IComparable<T>
    {
        if (items.Count() == 0)
        {
            throw new InvalidOperationException();
            
        }

        T max = items.First();
        foreach (var item in items)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }
        return max;
    }

}
