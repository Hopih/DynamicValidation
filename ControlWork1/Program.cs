using System;
using ControlWork1;

class Program
{
    static void Main()
    {
        /*
        Package package = new Package();
        package.Name = "Num1";
        package.Weight = 9;
        package.ExpirationDate = DateTime.Today;
        package.IsFragile = true;
        
        Package package2 = new Package();
        package2.Name = "Num2";
        package2.Weight = 11;
        package2.ExpirationDate = DateTime.Today;
        package.IsFragile = true;
        
        StorageBox<Package> numbers = new StorageBox<Package>();
        numbers.Add(package);
        numbers.Add(package2);
        
        Console.WriteLine("Все");
        foreach (Package item in numbers)
        {
            Console.WriteLine(item.Name);
        }
        Console.WriteLine("Не все");
        foreach (var item in numbers.GetAvailableFragilePackages())
        {
            Console.WriteLine(item.Name);
        }
        */

        IO result = new IO();
        result.Solve();

    }
}