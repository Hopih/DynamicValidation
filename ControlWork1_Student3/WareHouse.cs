namespace ControlWork1_Student3;

public class WareHouse
{
    public delegate void StockChangedEventArgs(string sender,string message);
    public event StockChangedEventArgs StockLow;
    
    public void RemoveFromStock(string productName, int amount)
    {
        foreach (var item in Program.items)
        {
            if (item.Name == productName)
            {
                item.Quantity-=amount;
                if (item.Quantity < 5)
                {
                    StockLow?.Invoke(productName, " меньше 5");
                }
            }
        }
    }
}
