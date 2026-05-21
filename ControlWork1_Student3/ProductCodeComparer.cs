namespace ControlWork1_Student3;
using System.Collections.Generic;

public class ProductCodeComparer : IEqualityComparer<Product>
{
    public  bool Equals(Product first, Product second)
    {
        return first.Code == second.Code;
    }

    public  int GetHashCode(Product obj)
    {
        return HashCode.Combine(obj.Code);
    }
}
