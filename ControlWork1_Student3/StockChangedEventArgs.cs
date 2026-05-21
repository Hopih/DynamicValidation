namespace ControlWork1_Student3;

public class StockChangedEventArgs : EventArgs
{
    public string ProductName { get; set; }
    public int OldQuantity { get; set; }
    public int NewQuantity { get; set; }
}