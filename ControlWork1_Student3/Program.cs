using System;
using ControlWork1_Student3;

class Program
{
    public static List<WarehouseItem> items = new List<WarehouseItem>();
    static void Main(string[] args)
    {
        WarehouseItem wi = new WarehouseItem();
        wi.Name = "Milk";
        wi.Quantity = 10;
        
        WarehouseItem wi2 = new WarehouseItem();
        wi2.Name = "Cheese";
        wi2.Quantity = 7;
        
        WarehouseItem wi3 = new WarehouseItem();
        wi3.Name = "Tomato";
        wi3.Quantity = 15;
        
        items.Add(wi);
        items.Add(wi2);
        items.Add(wi3);
        
        WareHouse warehouse = new WareHouse();
        warehouse.StockLow += (sender, msg) => Console.WriteLine("Низкий остаток: " + msg);

        warehouse.RemoveFromStock("Milk", 8); 
        
        Solution3.Solve();
    }
}