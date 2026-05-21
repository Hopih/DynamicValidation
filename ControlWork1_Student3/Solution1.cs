namespace ControlWork1_Student3;

public class Solution1
{
    static List<T> MergeUnique<T>(
        IEnumerable<T> first,
        IEnumerable<T> second,
        IEqualityComparer<T> comparer)
    {
        List<T> result = new List<T>();
        foreach (T item in first)
        {
            if (!second.Contains(item, comparer))
            {
                result.Add(item);
            }
        }
        return result;
    }
}